using System;
using Android.App;
using Firebase.Iid;
using Android.Util;

namespace Test0704.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class FirebaseIIDService : FirebaseInstanceIdService
    {
        public override void OnTokenRefresh()
        {
            var token = FirebaseInstanceId.Instance.Token;
            Console.WriteLine("Token Show:"+FirebaseInstanceId.Instance.Token);
            Log.Debug("NotificationApp Token", token);
        }
    }
}