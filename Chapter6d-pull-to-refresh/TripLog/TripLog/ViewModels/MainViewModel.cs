﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TripLog.Models;
using TripLog.Services;
using Xamarin.Forms;

namespace TripLog.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        ObservableCollection<TripLogEntry> _logEntries;

        public ObservableCollection<TripLogEntry> LogEntries {
            get => _logEntries;
            set { _logEntries = value; OnPropertyChanged(); }
        }

        public MainViewModel(INavService navService) : base(navService)
        {
            LogEntries = new ObservableCollection<TripLogEntry>();
        }

        public override void Init()
        {
            LoadEntries();
        }

        Command _refreshCommand;
        public Command RefreshCommand =>
            _refreshCommand ?? (_refreshCommand = new Command(LoadEntries));

        void LoadEntries()
        {
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;
            LogEntries.Clear();
            // TODO: Remove this in chapter 6 
            Task.Delay(3000).ContinueWith(_ => Device.BeginInvokeOnMainThread(() =>
            {
                LogEntries.Add(new TripLogEntry
                {
                    Title = "La Elipa",
                    Notes = "Si que flipa",
                    Rating = 3,
                    Date = new DateTime(2019, 2, 5),
                    Latitude = 40.4246727,
                    Longitude = -3.652186
                });
                LogEntries.Add(new TripLogEntry
                {
                    Title = "Statue of Liberty",
                    Notes = "Inspiring!",
                    Rating = 4,
                    Date = new DateTime(2019, 4, 13),
                    Latitude = 40.6892,
                    Longitude = -74.0444
                });
                LogEntries.Add(new TripLogEntry
                {
                    Title = "Golden Gate Bridge",
                    Notes = "Foggy, but beautiful.",
                    Rating = 5,
                    Date = new DateTime(2019, 4, 26),
                    Latitude = 37.8268,
                    Longitude = -122.4798
                });

                IsBusy = false;
            }));
        }

        public Command<TripLogEntry> ViewCommand =>
        new Command<TripLogEntry>(async entry =>
            await NavService.NavigateTo<DetailViewModel, TripLogEntry>(entry));

        public Command NewCommand =>
            new Command(async () =>
                await NavService.NavigateTo<NewEntryViewModel>());
    }
}
