using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoKnowApplication.Entities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using NoKnowApplication.Models;
using NoKnowApplication.Views.Settings;
using NoKnowApplication.ViewModels;
using NoKnowApplication.ViewModels.Account;

namespace NoKnowApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginViewModel viewModel;

        public LoginPage(string username = "", string password = "")
        {
            InitializeComponent();
            if (password != "" && username != "")
            {
                Passwort.Text = password;
                UsernameEmail.Text = username;
            }
            BindingContext = viewModel = new LoginViewModel();
        }

        async void OnRegistrierenClick(object sender, EventArgs e)
        {
           Application.Current.MainPage = new RegistrationPage();
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var user = new AccountEntity
            {
                Username = UsernameEmail.Text,
                Email = UsernameEmail.Text,
                Password = Passwort.Text
            };

            var isValid = AreCredentialsCorrect(user);
            if (isValid)
            {
                 List<AreaConfigurationEntity> config = await MobileService.MobileServiceClient.GetTable<AreaConfigurationEntity>().ToListAsync();
                 ApplicationHandler.AreaConfiguration =
                     config.Where(x => x.AccountId == ApplicationHandler.LoggedInAccount.Id).First();
                 App.IsUserLoggedIn = true;
                Application.Current.MainPage = new MainPage();
            }
            else
            {
                //FEHLERMELDUNG
            }
        }

        bool AreCredentialsCorrect(AccountEntity user)
        {
            var accounts = ApplicationHandler.AllAccounts.Where(x =>
                x.Password == Passwort.Text && (x.Username == UsernameEmail.Text || x.Email == UsernameEmail.Text));
            if (accounts.Any())
            {
                ApplicationHandler.LoggedInAccount = accounts.First();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}