using System;
using System.Collections.ObjectModel;
using System.Windows;
using OnHandTracker.Core;
using Prism.Mvvm;
using Prism.Regions;

namespace OnHandTracker.Modules.OnHand.ViewModels
{
    public class OnHandViewModel : BindableBase, INavigationAware
    {
        private ObservableCollection<StationSummaryViewModel> StationSummaries { get; }

        private StationSummaryViewModel _selectedStationSummary;

        public StationSummaryViewModel SelectedStationSummary {
            get => _selectedStationSummary;
            set => SetProperty(ref _selectedStationSummary, value);
        }

        public OnHandViewModel()
        {
            StationSummaries = new ObservableCollection<StationSummaryViewModel>
            {
                new StationSummaryViewModel{ Label = "Recycle" },
                new StationSummaryViewModel{ Icon = Icons.Settings, Label = "Settings" }
            };
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var action = (Action<OnHandViewModel>)navigationContext.Parameters["Action"];
            action(this);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void CreateNewOnHand()
        {
            MessageBox.Show("Test Create New");
        }

        public void OpenOnHand(string filename)
        {
            MessageBox.Show($"Test Open: {filename}");
        }
    }
}