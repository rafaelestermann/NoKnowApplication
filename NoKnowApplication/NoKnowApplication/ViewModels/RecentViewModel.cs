using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace NoKnowApplication.ViewModels
{
    public class RecentViewModel : BaseViewModel
    {
        public RecentViewModel()
        {
            Title = "Recents";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        public ICommand OpenWebCommand { get; }
    }
}