using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test0704
{
    public partial class App : Application
    {
        public App(string linkAssigned)
        {
            InitializeComponent();
            Console.WriteLine("LinkAssigned At Xamarin Forms "+linkAssigned);
            MainPage = new MainPage(linkAssigned);
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
