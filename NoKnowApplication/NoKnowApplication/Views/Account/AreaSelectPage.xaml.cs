using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoKnowApplication.Models;

namespace NoKnowApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AreaSelectPage : ContentPage
    {
        private RegistrationPage previouspage;
        private PolicyAgreementPage nextpage;
        private object SelectedKanton;
        private object SelectedGemeinde;

        public AreaSelectPage(RegistrationPage page)
        {
            InitializeComponent();
            KantonListe.ItemsSource = GetKantone();
            GemeindeListe.ItemsSource = GetGemeinden();
            KantonListe.SelectedItem = KantonListe.Items.First();
            GemeindeListe.SelectedItem = GemeindeListe.Items.First();
            previouspage = page;
            WeiterButton.IsEnabled = false;
        }

        private IList GetGemeinden()
        {
            var gemeinden = new List<ListItem>();
            gemeinden.Add(new ListItem());
            gemeinden.Add(new ListItem() { Description = "Kriens" });
            gemeinden.Add(new ListItem() { Description = "Horgen" });
            gemeinden.Add(new ListItem() { Description = "Harbbach" });
            return gemeinden;
        }

        private IList GetKantone()
        {
            var kantone = new List<ListItem>();
            kantone.Add(new ListItem());
            kantone.Add(new ListItem() { Description = "Luzern" });
            kantone.Add(new ListItem() { Description = "Zürich" });
            kantone.Add(new ListItem() { Description = "Basel" });
            return kantone;
        }

        async void OnBackClick(object sender, EventArgs e)
        {
            Application.Current.MainPage = previouspage;
        }

        async void OnNextClick(object sender, EventArgs e)
        {
            if (WeiterButton.IsEnabled)
            {
                Application.Current.MainPage = new PolicyAgreementPage(this);
            }
        }

        async void OnSelected(object sender, EventArgs e)
        {
            var noKantonSelected = ((ListItem)(KantonListe.SelectedItem)) == null || ((ListItem) (KantonListe.SelectedItem)).Description == null;
            var noGemeindeSelected = ((ListItem)(GemeindeListe.SelectedItem)) == null || ((ListItem)(GemeindeListe.SelectedItem)).Description == null;
            if (noGemeindeSelected && noKantonSelected && !AllSwiss.IsToggled)
            {
                WeiterButton.IsEnabled = false;
            }
            else
            {
                WeiterButton.IsEnabled = true;
            }
        }
        async void OnToggled(object sender, EventArgs e)
        {
            if (AllSwiss.IsToggled)
            {
                SelectedKanton = KantonListe.SelectedItem;
                SelectedGemeinde = GemeindeListe.SelectedItem;
                KantonListe.SelectedItem = null;
                GemeindeListe.SelectedItem = null;
                KantonListe.IsEnabled = false;
                GemeindeListe.IsEnabled = false;
                WeiterButton.IsEnabled = true;
            }
            else
            {
                KantonListe.SelectedItem = SelectedKanton;
                GemeindeListe.SelectedItem = SelectedGemeinde;
                KantonListe.IsEnabled = true;
                GemeindeListe.IsEnabled = true;
                if (KantonListe.SelectedItem == null && GemeindeListe.SelectedItem == null)
                {
                    WeiterButton.IsEnabled = false;
                }
            }
        }
    }
}