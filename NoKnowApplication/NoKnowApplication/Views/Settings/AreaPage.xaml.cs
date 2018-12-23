using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using NoKnowApplication.Models;
using NoKnowApplication.ViewModels;

namespace NoKnowApplication.Views.Settings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AreaPage : ContentPage
    {
        AreaViewModel viewModel;

        public AreaPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new AreaViewModel();
        }
    }
}