using Prism.Mvvm;

namespace OnHandTracker.WpfApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "OnHandTracker";

        public string Title {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public MainWindowViewModel() { }
    }
}