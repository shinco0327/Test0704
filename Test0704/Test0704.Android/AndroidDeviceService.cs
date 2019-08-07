/*
 * 運用DependencyService與Shared Code溝通
 * https://docs.microsoft.com/zh-tw/xamarin/xamarin-forms/app-fundamentals/dependency-service/
 */
using System;
using System.IO;
using Android.App;
using Android.Content;
using Android.Media;
using Android.Util;
using Xamarin.Forms;


namespace Test0704.Droid
{
    public class AndroidDeviceService: IDeviceService
    {
        public string GetTitle()
        {
            return title;
        }
        public string GetBody()
        {
            return body;
        }
        public void SetContent(string title_in,string body_in)
        {
            title = title_in;
            body = body_in;
        }
        static private string title;
        static private string body;
    }
};
