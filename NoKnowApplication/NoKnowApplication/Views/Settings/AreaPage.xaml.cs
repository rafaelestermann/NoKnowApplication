using System;
using System.Collections.Generic;
using System.Linq;
using NoKnowApplication.Entities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using NoKnowApplication.Models;
using NoKnowApplication.Services;
using NoKnowApplication.ViewModels;

namespace NoKnowApplication.Views.Settings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AreaPage : ContentPage
    {
        AreaViewModel viewModel;
        private object SelectedKanton;
        private object SelectedGemeinde;
        private AreaConfigurationEntity areaConfiguration;

        public AreaPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new AreaViewModel();
            GemeindeListe.ItemsSource = viewModel.GemeindeListe;
            KantonListe.ItemsSource = viewModel.KantonListe;
            var selectedGemeinde = ApplicationHandler.Gemeinden.FirstOrDefault(x => x.Id == ApplicationHandler.AreaConfiguration.GemeindeId);
            var selectedKanton = ApplicationHandler.Kantone.FirstOrDefault(x => x.Id == ApplicationHandler.AreaConfiguration.KantonId);
           
            areaConfiguration = ApplicationHandler.AreaConfiguration;
            if (selectedGemeinde == null && selectedKanton == null)
            {
                GemeindeListe.SelectedItem = GemeindeListe.Items.First();
                KantonListe.SelectedItem = KantonListe.Items.First();
                AllSwiss.IsToggled = true;
                OnToggled(null,null);

            }
            else
            {
                if (selectedGemeinde != null)
                {
                    GemeindeListe.SelectedItem = GemeindeListe.Items.Where(item => item == selectedGemeinde.Bezeichnung)
                        .FirstOrDefault();
                    GemeindeListe.SelectedIndex = GemeindeListe.Items.IndexOf(GemeindeListe.Items.Where(item => item == selectedGemeinde.Bezeichnung).FirstOrDefault());
                }
                
                if (selectedKanton != null)
                {
                    KantonListe.SelectedItem = KantonListe.Items.Where(item => item == selectedKanton.Bezeichnung)
                        .FirstOrDefault();
                    KantonListe.SelectedIndex = KantonListe.Items.IndexOf(KantonListe.Items.Where(item => item == selectedKanton.Bezeichnung).FirstOrDefault());
                }
            }
        }
        
        async void OnSelected(object sender, EventArgs e)
        {
            var noKantonSelected = ((KantonEntity)(KantonListe.SelectedItem)) == null || ((KantonEntity)(KantonListe.SelectedItem)).Bezeichnung == null;
            var noGemeindeSelected = ((GemeindeEntity)(GemeindeListe.SelectedItem)) == null || ((GemeindeEntity)(GemeindeListe.SelectedItem)).Bezeichnung == null;
            if ((noGemeindeSelected && noKantonSelected && !AllSwiss.IsToggled))
            {
                SpeichernButton.IsEnabled = false;
            }
            else
            {
                SpeichernButton.IsEnabled = true;
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
                SpeichernButton.IsEnabled = true;
            }
            else
            {
                KantonListe.SelectedItem = SelectedKanton;
                GemeindeListe.SelectedItem = SelectedGemeinde;
                KantonListe.IsEnabled = true;
                GemeindeListe.IsEnabled = true;
                if (KantonListe.SelectedItem == null && GemeindeListe.SelectedItem == null)
                {
                    SpeichernButton.IsEnabled = false;
                }
            }
        }

        async void OnSpeichernClicked(object sender, EventArgs e)
        {
            if (SpeichernButton.IsEnabled)
            {
                var area = new AreaConfigurationEntity()
                {
                    AccountId = areaConfiguration.AccountId,
                    Id = areaConfiguration.Id,
                    GemeindeId = GemeindeListe.SelectedItem == null ? null : ((GemeindeEntity)(GemeindeListe.SelectedItem)).Id,
                    KantonId = KantonListe.SelectedItem == null ? null : ((KantonEntity)(KantonListe.SelectedItem)).Id
                };
                await MobileService.MobileServiceClient.GetTable<AreaConfigurationEntity>().UpdateAsync(area);
                ApplicationHandler.AreaConfiguration = area;
                await Navigation.PopAsync();
            }
        }
    }
}