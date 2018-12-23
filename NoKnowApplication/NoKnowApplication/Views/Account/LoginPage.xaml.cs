using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public LoginPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new LoginViewModel();
        }

        async void OnRegistrierenClick(object sender, EventArgs e)
        {
           Application.Current.MainPage = new RegistrationPage();
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var user = new User
            {
                Username = UsernameEmail.Text,
                Email = UsernameEmail.Text,
                Password = Passwort.Text
            };

            var isValid = AreCredentialsCorrect(user);
            if (isValid)
            {
                App.IsUserLoggedIn = true;
                Application.Current.MainPage = new MainPage();
            }
            else
            {
                //FEHLERMELDUNG
            }
        }

        bool AreCredentialsCorrect(User user)
        {
            return true;
            //SERVICE QUERY
        }

    }
}