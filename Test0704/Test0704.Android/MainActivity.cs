using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;
using Firebase.Iid;
using Android.Content;
using Xamarin.Forms;

namespace Test0704.Droid
{
    [Activity(Label = "Test0704", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            DependencyService.Register<AndroidDeviceService>();
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            //當點選狀態列的訊息後，若這個訊息有附帶Data(Key/Value)則會進行以下動作
            if (Intent.Extras != null)
            {
                foreach (var key in Intent.Extras.KeySet())
                {
                    if (key != null)
                    {
                        var value = Intent.Extras.GetString(key);
                        Log.Debug("Programer", "Key: {0} Value: {1}", key, value);
                        if (key == "LinkAssigned")
                        {
                            Assign_Link = value;
                            Log.Debug("Programer", "GotData Key: {0} Value: {1}", key, Assign_Link);
                        }
                    }
                                      
                }
            }
            //End of if
            Log.Debug("Programer", "LinkAssign Check "+Assign_Link);
           // Log.Debug("NotificationApp Token", FirebaseInstanceId.Instance.Token);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App(Assign_Link));
        }
        private string Assign_Link;
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            Log.Debug("NotificationApp Token", FirebaseInstanceId.Instance.Token);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}