using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using NoKnowApplication.Entities;
using NoKnowApplication.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoKnowApplication.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace NoKnowApplication
{
    public partial class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }

        public App()
        {
            if (!IsUserLoggedIn)
            {
                MainPage = new LoginRegistrationPage();
            }
            else
            {
                MainPage = new MainPage();
            }
        }

        protected async override void OnStart()
        {
            ApplicationHandler.Kantone = await MobileService.MobileServiceClient.GetTable<KantonEntity>().ToListAsync();
            ApplicationHandler.Gemeinden = await MobileService.MobileServiceClient.GetTable<GemeindeEntity>().ToListAsync();
            ApplicationHandler.AllAccounts = await MobileService.MobileServiceClient.GetTable<AccountEntity>().ToListAsync();
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

