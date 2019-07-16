using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(IDeviceService))]
namespace Test0704.iOS
{
    class iOSDeviceService : IDeviceService
    {
        public string GetTitle()
        {
            return title;
        }
        public string GetBody()
        {
            return body;
        }
        public void SetContent(string title_in, string body_in)
        {
            title = title_in;
            body = body_in;
        }
        static private string title;
        static private string body;
    }
}