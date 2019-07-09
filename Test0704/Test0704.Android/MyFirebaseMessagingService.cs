using System;
//using System.IO;
using Android.App;
using Android.Content;
using Android.Media;
using Android.Util;
using Firebase.Messaging;
using System.Threading.Tasks; //TASK
using Xamarin.Forms;


namespace Test0704.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseMessagingService : FirebaseMessagingService
    {
        const string TAG = "MyFirebaseMsgService";
        public override void OnMessageReceived(RemoteMessage message)
        {
            string MSG_title = message.GetNotification().Title;
            string MSG_body = message.GetNotification().Body;
            Log.Debug(TAG, "From: " + message.From);
            Log.Debug(TAG, "Title:" + MSG_title);
            Log.Debug(TAG, "Notification Message Body: " + MSG_body);
            /*
             * Old Solution "Sending FCM Data to PLC"
             * Using File IO
            string filename;
            filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "FCM_Message.txt");
            File.Delete(filename);
            File.WriteAllText(filename, MSG_title + "@EoT23321899" + MSG_body);
            */
            var IDService = new AndroidDeviceService();
            IDService.SetContent(MSG_title,MSG_body);
        }

       
        

    }
}



/*
 MyFirebaseMessageingService.cs is used for receiving Firebase Cloud Messages while APP IS RUNNING FORTHGROUND.
 You can sent messages via FCM to user while they are using this application.
 If the app is not supposed to reciveing FCM message while running just DELETE MyFirebaseMessageingService.cs and
 remove programs marked "Used for FCM Forthground Receive"

 當APP正在運行的時候，若要接收FCM訊息並透過DisplayAlert快顯顯示，便需要這段程式
 如果APP不需要此功能，即刪除本MyFirebaseMessageingService.cs檔案
 和在MainPage.xaml.cs中用註解"Used for FCM Forthground Receive"標示的程式碼即可。
 
 */
