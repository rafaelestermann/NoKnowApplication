using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using NoKnowApplication.Models;
using Xamarin.Forms;

namespace NoKnowApplication.ViewModels
{
    public class SettingViewModel : BaseViewModel
    {
        public ObservableCollection<ListItem> SettingItems { get; set; }
        public SettingViewModel()
        {
            Title = "Settings";
            SettingItems = new ObservableCollection<ListItem>();

            SettingItems.Add(new ListItem(){Text = "Area"});
            SettingItems.Add(new ListItem() { Text = "Passwort ändern" });
            SettingItems.Add(new ListItem() { Text = "Log Out" });
        }
    }
}