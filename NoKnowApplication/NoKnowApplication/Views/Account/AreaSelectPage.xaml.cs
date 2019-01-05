using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using NoKnowApplication.Entities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoKnowApplication.Models;
using NoKnowApplication.Services;

namespace NoKnowApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AreaSelectPage : ContentPage
    {
        public RegistrationPage previouspage;
        private PolicyAgreementPage nextpage;
        public AreaConfigurationEntity areaConfigurationEntity;
        private object SelectedKanton;
        private object SelectedGemeinde;
        private KantonService kantonService;
        private GemeindeService gemeindeService;
        private AccountService accountService;

        public AreaSelectPage(RegistrationPage page)
        {
            InitializeComponent();
            //Kantone befüllen
            List<KantonEntity> kantone = new List<KantonEntity>();
            kantone.Add(new KantonEntity());
            kantone.AddRange(ApplicationHandler.Kantone);

            List<GemeindeEntity> gemeinden = new List<GemeindeEntity>();
            gemeinden.Add(new GemeindeEntity());
            gemeinden.AddRange(ApplicationHandler.Gemeinden);

            KantonListe.ItemsSource = kantone;
            GemeindeListe.ItemsSource = gemeinden;
            KantonListe.SelectedItem = KantonListe.Items.First();
            GemeindeListe.SelectedItem = GemeindeListe.Items.First();
            previouspage = page;
            WeiterButton.IsEnabled = false;
        }

        async void OnBackClick(object sender, EventArgs e)
        {
            Application.Current.MainPage = previouspage;
        }

        async void OnNextClick(object sender, EventArgs e)
        {
            if (WeiterButton.IsEnabled)
            {
                if (AllSwiss.IsToggled)
                {
                    areaConfigurationEntity = new AreaConfigurationEntity()
                    {
                 
                    };
                }
                else
                {
                    areaConfigurationEntity = new AreaConfigurationEntity()
                    {
                        GemeindeId = GemeindeListe.SelectedItem == null ? null : ((GemeindeEntity)(GemeindeListe.SelectedItem)).Id,
                        KantonId = KantonListe.SelectedItem == null ? null : ((KantonEntity)(KantonListe.SelectedItem)).Id
                    };
                }
     

             Application.Current.MainPage = new PolicyAgreementPage(this);
            }
        }

        async void OnSelected(object sender, EventArgs e)
        {
            var noKantonSelected = ((KantonEntity)(KantonListe.SelectedItem)) == null || ((KantonEntity) (KantonListe.SelectedItem)).Bezeichnung == null;
            var noGemeindeSelected = ((GemeindeEntity)(GemeindeListe.SelectedItem)) == null || ((GemeindeEntity)(GemeindeListe.SelectedItem)).Bezeichnung == null;
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