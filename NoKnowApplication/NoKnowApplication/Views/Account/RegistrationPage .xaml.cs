using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.MobileServices;
using NoKnowApplication.Entities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoKnowApplication.Models;
using NoKnowApplication.Services;
using NoKnowApplication.Views.Settings;

namespace NoKnowApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public AccountEntity accountEntity;

        public RegistrationPage()
        {
            InitializeComponent();
        }

        async void OnLoginClick(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LoginPage(ApplicationHandler.LoggedInAccount.Username, ApplicationHandler.LoggedInAccount.Password);
        }

        async void OnNextClick(object sender, EventArgs e)
        {
            accountEntity = new AccountEntity()
            {
                Username = Username.Text,
                Password = Passwort.Text,
                Email = Email.Text
            };

            // Sign up logic goes here
            if (AreDetailsValid(accountEntity))
            {
                if (ApplicationHandler.Kantone == null || ApplicationHandler.Gemeinden == null)
                {
                    ApplicationHandler.Kantone = await MobileService.MobileServiceClient.GetTable<KantonEntity>().ToListAsync();
                    ApplicationHandler.Gemeinden = await MobileService.MobileServiceClient.GetTable<GemeindeEntity>().ToListAsync();
                }
                Application.Current.MainPage = new AreaSelectPage(this);
            }
            else
            {
                //ERROR WERFEN
            }
        }

        bool AreDetailsValid(AccountEntity user)
        {
            return true;
        }
    }
}