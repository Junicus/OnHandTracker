using System;
using System.Windows.Input;
using OnHandTracker.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace OnHandTracker.Modules.OnHand.ViewModels
{
    public class StartupMenuItemViewModel : BindableBase
    {
        private Icons _icon;
        public Icons Icon {
            get => _icon;
            set => SetProperty(ref _icon, value);
        }

        private string _label;
        public string Label {
            get => _label;
            set => SetProperty(ref _label, value);
        }

        public DelegateCommand MenuCommand { get; private set; }

        public StartupMenuItemViewModel(DelegateCommand menuCommand)
        {
            MenuCommand = menuCommand;
        }
    }
}