using System;
using OnHandTracker.Core;
using Prism.Mvvm;

namespace OnHandTracker.Modules.OnHand.ViewModels
{
    public class StationSummaryViewModel : BindableBase
    {
        private string _label;
        public string Label {
            get => _label;
            set => SetProperty(ref _label, value);
        }

        private Icons _icon;
        public Icons Icon {
            get => _icon;
            set => SetProperty(ref _icon, value);
        }

        public StationSummaryViewModel()
        {
            Icon = Icons.None;
            Label = string.Empty;
        }
    }
}