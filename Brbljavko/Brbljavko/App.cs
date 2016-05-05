using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brbljavko.Pages;
using Brbljavko.Services;
using Xamarin.Forms;

namespace Brbljavko
{
    public class App : Application
    {
        public static DataService DataService { get; set; }
        public App()
        {
            DataService=new DataService();
            // The root page of your application
            MainPage = new NavigationPage(new LoginPage());
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
