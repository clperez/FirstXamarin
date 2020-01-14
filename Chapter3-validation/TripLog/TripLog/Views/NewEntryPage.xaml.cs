using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripLog.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TripLog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewEntryPage : ContentPage
    {
        public NewEntryPage()
        {
            InitializeComponent();
            this.BindingContext = new NewEntryViewModel();

        }
    }
}