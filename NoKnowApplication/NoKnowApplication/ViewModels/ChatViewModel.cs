using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using NoKnowApplication.Models;
using NoKnowApplication.Views;

namespace NoKnowApplication.ViewModels
{
    public class ChatViewModel : BaseViewModel
    {
        public ObservableCollection<ListItem> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ChatViewModel()
        {
            Title = "Chat";
            Items = new ObservableCollection<ListItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, ListItem>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as ListItem;
                Items.Add(newItem);
              
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
             
            
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}