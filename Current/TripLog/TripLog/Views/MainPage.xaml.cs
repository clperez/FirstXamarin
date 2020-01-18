using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripLog.Models;
using TripLog.Services;
using TripLog.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TripLog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        MainViewModel ViewModel => BindingContext as MainViewModel;
        // ...
        protected override void OnAppearing()
        {
            base.OnAppearing();
            // Initialize MainViewModel
            ViewModel?.Init();
        }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel(DependencyService.Get<INavService>());
        }
    }
}