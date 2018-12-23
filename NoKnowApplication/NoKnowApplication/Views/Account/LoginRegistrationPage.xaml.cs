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
    public partial class LoginRegistrationPage : ContentPage
    {
        LoginViewModel viewModel;

        public LoginRegistrationPage()
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
            Application.Current.MainPage = new LoginPage();
        }

    }
}