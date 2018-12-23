using System;

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
        }
    }
}