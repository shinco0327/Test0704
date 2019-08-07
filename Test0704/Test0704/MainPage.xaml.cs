/*
 * MainPage.xaml.cs
 * Date:2019/8/7
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            GetIDService_Content(); //呼叫GetIDService_Content() 當App在前景運作時，向使用者推撥訊息 不需要可移除
            browser.Source = Index_Link;    //Set the webview link to private const string Index_Link
            Content = browser;
            browser.Navigated += OnNavigatedHandler; //public void OnNavigatedHandler

            //If the device received the FCM Message before the app launched with Tag "LinkAssigned"
            //The code at the entrypoint of both Android and iOS will handle the tag and Data
            //Once getting the tag "LinkAssigned", the the data of the message will be sent to here
            if (LinkAssigned != null)   
            {
                browser.Source = LinkAssigned;  //The link is changed
                //For Debug
                //Console.WriteLine("LinkAssigned changed webpage source!" + LinkAssigned);
                IsLinkAssigned = LinkAssigned;
                LinkAssigned = null;
            }
        }

        //GerIDService_Content()
        //Handle the FCM message while in forthground
        //當App在前景運作時，向使用者推撥訊息
        //將會以DisplayAlert的方式將訊息的key與value顯示出來
        //假如不需要此功能 可移除
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
                    //For Debug
                    //Console.WriteLine("FromAndroid Title: " + IDService_title + " Body: " + IDService_body);
                    DisplayAlert(IDService_title, IDService_body, "OK");
                }
                device_service.SetContent(null,null);
                await Task.Delay(250);
            }
        }
        

        //private Webview browser
        private WebView browser = new WebView
        {
            Source = Index_Link
        };

        //取得現在的Url
        public void OnNavigatedHandler(object sender, WebNavigatedEventArgs args)
        {
            //For Debug
            //Console.WriteLine("Is URI changed? LinkAssigned  " + args.Url);
        }

        private const string Index_Link = "https://24h.pchome.com.tw"; //The link of Index 
        private string IsLinkAssigned; //Store the link from Firebase Message Service

        //處理返回鍵按下時的工作
        /*目前流程：
         *按下返回鍵時返回瀏覽器上一頁
         *若CanGOBack == false 則返回Index_Link的網頁
         *若CanGOBack == false，運行平台為Android則呼叫ExitTheApp()函數，iOS平台無法使用
        */
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

        //當Toolbar的返回鍵被按下時 返回前一頁
        async void Back_Pressed(object sender,EventArgs args)
        {
            if (browser.CanGoBack)
            {
                browser.GoBack();
            }
        }

        //Android平台使用
        //顯示對話窗：是否要離開App
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
