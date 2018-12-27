using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoKnowApplication.Models;
using NoKnowApplication.Views.Settings;

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

        async void OnNextClick(object sender, EventArgs e)
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
                    Application.Current.MainPage = new AreaSelectPage(this);
                
            }
            else
            {
                //ERROR WERFEN
            }
        }

        bool AreDetailsValid(User user)
        {
            return true;
        }
    }
}