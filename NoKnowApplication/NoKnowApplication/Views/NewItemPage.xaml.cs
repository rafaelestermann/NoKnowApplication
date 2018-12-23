using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using NoKnowApplication.Models;

namespace NoKnowApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public ListItem ListItem { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            ListItem = new ListItem
            {
                Text = "ListItem name",
                Description = "This is an listItem description."
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", ListItem);
            await Navigation.PopModalAsync();
        }
    }
}