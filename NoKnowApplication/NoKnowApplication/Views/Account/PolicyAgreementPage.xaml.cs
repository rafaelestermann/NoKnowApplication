using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoKnowApplication.Models;

namespace NoKnowApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PolicyAgreementPage : ContentPage
    {
        private readonly AreaSelectPage previouspage;

        public PolicyAgreementPage(AreaSelectPage page)
        {
            previouspage = page;
            InitializeComponent();
            AgreeButton.IsEnabled = false;
        }

        async void OnBackClick(object sender, EventArgs e)
        {
            Application.Current.MainPage = previouspage;
        }

        async void OnNextClick(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = true;
            Application.Current.MainPage = new MainPage();
        }

        async void OnAgree(object sender, EventArgs e)
        {
            if (AgreeBox.IsToggled)
            {
                AgreeButton.IsEnabled = true;
            }
            else
            {
                AgreeButton.IsEnabled = false;
            }
        }
    }
}