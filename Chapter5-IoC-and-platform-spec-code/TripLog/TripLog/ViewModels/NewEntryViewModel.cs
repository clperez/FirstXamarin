using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripLog.Models;
using TripLog.Services;
using Xamarin.Forms;

namespace TripLog.ViewModels
{
    public class NewEntryViewModel : BaseValidationViewModel
    {
        readonly ILocationService _locService;

        public NewEntryViewModel(INavService navService, ILocationService locService) : base(navService)
        {
            _locService = locService;
            Date = DateTime.Today;
            Rating = 1;
        }

        public async override void Init()
        {
            try
            {
                var coords = await _locService.GetGeoCoordinatesAsync();
                Latitude = coords.Latitude;
                Longitude = coords.Longitude;
            }
            catch (Exception)
            {
                // TODO: handle exceptions from location service
            }
        }

        string _title;
        public string Title {
            get => _title;
            set
            {
                _title = value;
                Validate(() => !string.IsNullOrWhiteSpace(_title), "Title must be provided.");
                OnPropertyChanged();
                SaveCommand.ChangeCanExecute();
            }
        }
        double _latitude;
        public double Latitude {
            get => _latitude;
            set
            {
                _latitude = value;
                OnPropertyChanged();
            }
        }
        double _longitude;
        public double Longitude {
            get => _longitude;
            set
            {
                _longitude = value;
                OnPropertyChanged();
            }
        }
        DateTime _date;
        public DateTime Date {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }
        int _rating;
        public int Rating {
            get => _rating;
            set
            {
                _rating = value;
                Validate(() => _rating >= 1 && _rating <= 5, "Rating must be between 1 and 5.");
                OnPropertyChanged();
                SaveCommand.ChangeCanExecute();
            }
        }
        string _notes;
        public string Notes {
            get => _notes;
            set
            {
                _notes = value;
                OnPropertyChanged();
            }
        }

        Command _saveCommand;
        public Command SaveCommand => _saveCommand ?? (_saveCommand = new Command(async () => await Save(), CanSave));

        async Task Save()
        {
            var newItem = new TripLogEntry
            {
                Title = Title,
                Latitude = Latitude,
                Longitude = Longitude,
                Date = Date,
                Rating = Rating,
                Notes = Notes
            };
            // TODO: Persist entry in a later chapter
            await NavService.GoBack();
        }
        bool CanSave() => !string.IsNullOrWhiteSpace(Title) && !HasErrors;

    }
}