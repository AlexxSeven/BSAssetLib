using System;
using System.ComponentModel;
using System.Linq;
using BSAssetLib.Providers;
using Zenject;

namespace BSAssetLib.Installers
{
    internal class BSAssetLibPlayerInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GameProvider>().AsSingle().NonLazy();
        }
    }
}
