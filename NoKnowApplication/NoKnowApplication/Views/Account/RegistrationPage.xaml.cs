using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoKnowApplication.Models;

namespace NoKnowApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        async void OnLoginClick(object sender, EventArgs e)
        {
           Application.Current.MainPage = new LoginPage();
        }

        async void OnRegistrationClick(object sender, EventArgs e)
        {
            var user = new User()
            {
                Username = Username.Text,
                Password = Passwort.Text,
                Email = Email.Text
            };

            // Sign up logic goes here

            var signUpSucceeded = AreDetailsValid(user);
            if (signUpSucceeded)
            {
                var rootPage = Navigation.NavigationStack.FirstOrDefault();
                if (rootPage != null)
                {
                    App.IsUserLoggedIn = true;
                    Application.Current.MainPage = new MainPage();
                    await Navigation.PopToRootAsync();
                }
            }
            else
            {
                //ERROR WERFEN
            }
        }

        bool AreDetailsValid(User user)
        {
            return (!string.IsNullOrWhiteSpace(user.Username) && !string.IsNullOrWhiteSpace(user.Password) && !string.IsNullOrWhiteSpace(user.Email) && user.Email.Contains("@"));
        }
    }
}