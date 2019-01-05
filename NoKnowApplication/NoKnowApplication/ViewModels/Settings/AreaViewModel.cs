using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using NoKnowApplication.Entities;
using Xamarin.Forms;

using NoKnowApplication.Models;
using NoKnowApplication.Views;

namespace NoKnowApplication.ViewModels
{
    public class AreaViewModel : BaseViewModel
    {
        public ObservableCollection<ListItem> Items { get; set; }
        public List<KantonEntity> KantonListe { get; set; }

        public List<GemeindeEntity> GemeindeListe { get; set; }
        public AreaViewModel()
        {
            Title = "Area";
            KantonListe = new List<KantonEntity>();
            KantonListe.Add(new KantonEntity());
            KantonListe.AddRange(ApplicationHandler.Kantone);
            GemeindeListe = new List<GemeindeEntity>();
            GemeindeListe.Add(new GemeindeEntity());
            GemeindeListe.AddRange(ApplicationHandler.Gemeinden);
            Items = new ObservableCollection<ListItem>();
        }


    }
}