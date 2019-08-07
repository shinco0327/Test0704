using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test0704
{
    public partial class App : Application
    {
        public App(string LinkAssigned) 
        {
            InitializeComponent();
            //For Debug
            //Console.WriteLine("LinkAssigned At Xamarin Forms " + LinkAssigned);
            MainPage = new NavigationPage(new MainPage(LinkAssigned)); 
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
