using System;
using System.ComponentModel;
using System.Linq;
using AssetLib.Providers;
using Zenject;

namespace AssetLib.Installers
{
    internal class AssetLibPlayerInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GameProvider>().AsSingle().NonLazy();
        }
    }
}
