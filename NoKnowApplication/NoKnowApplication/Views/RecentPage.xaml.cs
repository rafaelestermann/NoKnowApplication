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

namespace NoKnowApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecentPage : ContentPage
    {
        RecentViewModel viewModel;

        public RecentPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new RecentViewModel();
            ItemsListView = new ListView(){};
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as ListItem;
            if (item == null)
                return;

            await Navigation.PushAsync(new AreaPage());

            // Manually deselect listItem.
            ItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}