using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using NoKnowApplication.Models;
using NoKnowApplication.Views;

namespace NoKnowApplication.ViewModels
{
    public class AreaViewModel : BaseViewModel
    {
        public ObservableCollection<ListItem> Items { get; set; }

        public AreaViewModel()
        {
            Title = "Area";
            Items = new ObservableCollection<ListItem>();
        }
    }
}