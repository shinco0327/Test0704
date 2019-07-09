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
            /*
            //"Used for FCM Forthground Receive" 
            //計時器：每10秒偵測FCM Cloud的訊息 並呼叫ShowMessage()顯示之
            //不需要此功能請刪除，副程式ShowMessage()也請刪除
            Device.StartTimer(TimeSpan.FromSeconds(10), () =>
            {
                ShowMessage();
                return true;
            });
            */
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
        async void ExitTheApp()
        {
            bool answer = await DisplayAlert("Leaving", "You're going to exiting the app", "Exit", "Cancel");
            if (answer)
            {
                System.Environment.Exit(0);
            }
        }

        /*
         * Old Solution "Receving FCM Data From Android Solution"
         * using File IO
         * 
        //"Used for FCM Forthground Receive"
        public void ShowMessage()
        {
            string filename;
            filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "FCM_Message.txt");
            if (File.Exists(filename)&&File.ReadAllText(filename)!=null)
            {
                string[] FCM_Content = System.Text.RegularExpressions.Regex.Split(File.ReadAllText(filename), "@EoT23321899", RegexOptions.IgnoreCase);
                if (FCM_Content.Length == 2 && (FCM_Content[0] != old_FCM_title || FCM_Content[1] != old_FCM_body))
                {
                    DisplayAlert(FCM_Content[0], FCM_Content[1], "OK");
                    Console.WriteLine("FCM got messages Title:" + FCM_Content[0] + "  Body:  " + FCM_Content[1]);
                    old_FCM_title = FCM_Content[0];
                    old_FCM_body = FCM_Content[1];
                }
                File.Delete(filename);
            }
        }
        private string old_FCM_title;
        private string old_FCM_body;
        //End of "Used for FCM Forthground Receive"
        */

    }
}
