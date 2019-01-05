using System;
using System.Linq;
using NoKnowApplication.Entities;
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
            AccountEntity account = previouspage.previouspage.accountEntity;
            account.Id = Guid.NewGuid().ToString();
            AreaConfigurationEntity area = previouspage.areaConfigurationEntity;
            area.AccountId = account.Id;
            ApplicationHandler.LoggedInAccount = account;
            ApplicationHandler.AreaConfiguration = area;
            await MobileService.MobileServiceClient.GetTable<AccountEntity>().InsertAsync(account);
            await MobileService.MobileServiceClient.GetTable<AreaConfigurationEntity>().InsertAsync(area);
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