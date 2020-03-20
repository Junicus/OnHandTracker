using System;
using OnHandTracker.Core;
using OnHandTracker.Modules.OnHand.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace OnHandTracker.Modules.OnHand
{
    public class OnHandModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public OnHandModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, $"StartupMenuView");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<StartupMenuView>();
            containerRegistry.RegisterForNavigation<OnHandView>();
        }
    }
}
