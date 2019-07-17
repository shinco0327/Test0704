using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Text.RegularExpressions; //Regular Expression
//using System.IO;  //File IO
using Xamarin.Forms;

namespace Test0704
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage(string LinkAssigned)
        {
            InitializeComponent();
            GetIDService_Content();
            browser.Source = Index_Link;
            Content = browser;
            browser.Navigated += OnNavigatedHandler;
            if (LinkAssigned != null)
            {
                browser.Source = LinkAssigned;
                Console.WriteLine("LinkAssigned changed webpage source!" + LinkAssigned);
                IsLinkAssigned = LinkAssigned;
                LinkAssigned = null;
            }
        }
        async void GetIDService_Content()
        {
            while (true)
            {
                var device_service = DependencyService.Get<IDeviceService>();
                string IDService_title;
                string IDService_body;
                IDService_title = device_service.GetTitle();
                IDService_body = device_service.GetBody();
                if (IDService_title != null || IDService_body != null)
                {
                    Console.WriteLine("FromAndroid Title: " + IDService_title + " Body: " + IDService_body);
                    DisplayAlert(IDService_title, IDService_body, "OK");
                }
                device_service.SetContent(null,null);
                await Task.Delay(250);
            }
        }

        private WebView browser = new WebView
        {
            Source = Index_Link
        };

        
        public void OnNavigatedHandler(object sender, WebNavigatedEventArgs args)
        {

            Console.WriteLine("Is URI changed? LinkAssigned  " + args.Url);
        }

        private const string Index_Link = "https://24h.pchome.com.tw";
        private string IsLinkAssigned;
        protected override bool OnBackButtonPressed()
        {
            if (browser.CanGoBack)
            {
                browser.GoBack();
            }
            else
            {
                if(IsLinkAssigned != null)
                {
                    App.Current.MainPage = new MainPage(null);
                }
                else if (Device.RuntimePlatform == Device.Android)
                {
                    ExitTheApp();
                }
            }
            return true;
        }

        async void Back_Pressed(object sender,EventArgs args)
        {
            if (browser.CanGoBack)
            {
                browser.GoBack();
            }
        }
        async void ExitTheApp()
        {
            bool answer = await DisplayAlert("Leaving", "You're going to exiting the app", "Exit", "Cancel");
            if (answer)
            {
                System.Environment.Exit(0);
            }
        }
    }
}
