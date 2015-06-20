using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VoucherDemo.Pages;
using VoucherDemo.ViewModels;
using Xamarin.Forms;

namespace VoucherDemo
{
    public class App : Application
    {
        public static MainViewModel MainVm { get; set; }

        public App()
        {
            MainVm = new MainViewModel();
            // The root page of your application
            MainPage = new NavigationPage(new MerchantLoginPage());
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
