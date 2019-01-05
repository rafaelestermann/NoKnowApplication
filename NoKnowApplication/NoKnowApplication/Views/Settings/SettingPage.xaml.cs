using NoKnowApplication.Models;
using NoKnowApplication.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoKnowApplication.Views.Settings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingPage : ContentPage
    {
        private SettingViewModel viewModel;
        public SettingPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new SettingViewModel();
        }
        async void OnNavigation(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as ListItem;
            if (item == null)
                return;
            if (item.Text == "Area")
            {
                await Navigation.PushAsync(new AreaPage());
            }
            if (item.Text == "Passwort ändern")
            {
                await Navigation.PushAsync(new PasswortPage());
            }

            if (item.Text == "Log Out")
            {
                Application.Current.MainPage = new LoginPage(ApplicationHandler.LoggedInAccount.Username, ApplicationHandler.LoggedInAccount.Password);
            }

            // Manually deselect listItem.
            SettingItemsListView.SelectedItem = null;
        }

    }
}