using System;

using NoKnowApplication.Models;

namespace NoKnowApplication.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public ListItem ListItem { get; set; }
        public ItemDetailViewModel(ListItem listItem = null)
        {
            Title = listItem?.Text;
            ListItem = listItem;
        }
    }
}
