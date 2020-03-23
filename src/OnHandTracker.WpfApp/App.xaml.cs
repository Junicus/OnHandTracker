using System.Windows;
using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnHandTracker.Modules.OnHand;
using OnHandTracker.WpfApp.Views;
using Prism.DryIoc.Ioc;
using Prism.Ioc;
using Prism.Modularity;

namespace OnHandTracker.WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<OnHandModule>();
        }
    }
}
