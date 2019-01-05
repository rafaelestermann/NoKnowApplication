using System;
using NoKnowApplication.Entities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using NoKnowApplication.Models;
using NoKnowApplication.ViewModels;

namespace NoKnowApplication.Views.Settings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PasswortPage : ContentPage
    {
        PasswortViewModel viewModel;

        public PasswortPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new PasswortViewModel();
            SpeichernButton.IsEnabled = false;
        }
        async void OnOldInput(object sender, EventArgs e)
        {
            UpdateSpeichernButton();
        }
        async void OnNewInput(object sender, EventArgs e)
        {
            UpdateSpeichernButton();
        }
        async void OnNewInput2(object sender, EventArgs e)
        {
            UpdateSpeichernButton();
        }
        async void OnSpeichernClicked(object sender, EventArgs e)
        {
            if (SpeichernButton.IsEnabled)
            {
                if (altesPasswort.Text != ApplicationHandler.LoggedInAccount.Password)
                {
                    //FEHLER ALTES PASSWORT IST FALSCH
                    return;
                }
                if (neuesPasswort.Text != neuesPasswortwiederholung.Text)
                {
                    //neuePasswörter stimmen nicht überein
                    return;
                }
                ApplicationHandler.LoggedInAccount.Password = neuesPasswort.Text;
                await MobileService.MobileServiceClient.GetTable<AccountEntity>().UpdateAsync(ApplicationHandler.LoggedInAccount);
                await Navigation.PopAsync();
            }
        }

        private void UpdateSpeichernButton()
        {
            if (altesPasswort.Text != null && neuesPasswort.Text != null && neuesPasswortwiederholung.Text != null)
            {
                SpeichernButton.IsEnabled = true;
            }
            else
            {
                SpeichernButton.IsEnabled = false;
            }
        }
    }
}