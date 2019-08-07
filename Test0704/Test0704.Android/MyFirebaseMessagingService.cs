/*
 * 處理App於前景時的通知
 */
using System;
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
            /*
            For Debug
            Log.Debug(TAG, "From: " + message.From);
            Log.Debug(TAG, "Title:" + MSG_title);
            Log.Debug(TAG, "Notification Message Body: " + MSG_body);
           */
            var IDService = new AndroidDeviceService();
            IDService.SetContent(MSG_title,MSG_body);
        }

       
        

    }
}


