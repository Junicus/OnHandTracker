using System;
using System.Collections.ObjectModel;
using OnHandTracker.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace OnHandTracker.Modules.OnHand.ViewModels
{
    public class StartupMenuViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        public ObservableCollection<StartupMenuItemViewModel> Items { get; set; }

        public StartupMenuViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            OpenOnHandCommand = new DelegateCommand(OpenOnHandExecute);
            NewOnHandCommand = new DelegateCommand(NewOnHandExecute);

            Items = new ObservableCollection<StartupMenuItemViewModel>
            {
                new StartupMenuItemViewModel(OpenOnHandCommand)
                {
                    Icon = Icons.None,
                    Label = "Open..."
                },
                new StartupMenuItemViewModel(NewOnHandCommand)
                {
                    Icon = Icons.Settings,
                    Label = "New"
                }
            };
        }

        private void OpenOnHandExecute()
        {
            var filename = "test";
                var navigationParameters = new NavigationParameters
            {
                { "Action", new Action<OnHandViewModel>((onHandVm) => { onHandVm.OpenOnHand(filename);}) }
            };
            _regionManager.RequestNavigate(RegionNames.ContentRegion,
                new Uri("OnHandView", UriKind.Relative), navigationParameters);
        }

        private void NewOnHandExecute()
        { 
            var navigationParameters = new NavigationParameters
            {
                { "Action", new Action<OnHandViewModel>((onHandVm) => { onHandVm.CreateNewOnHand();}) }
            };
            _regionManager.RequestNavigate(RegionNames.ContentRegion,
                new Uri("OnHandView", UriKind.Relative), navigationParameters);
        }

        private DelegateCommand OpenOnHandCommand { get; }
        private DelegateCommand NewOnHandCommand { get; }
    }
}