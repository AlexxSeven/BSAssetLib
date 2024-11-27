using System;
using System.Linq;
using AssetLib.Providers;
using Zenject;

namespace AssetLib.Installers
{
    internal class AssetLibMenuInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MenuProvider>().AsSingle();
        }
    }
}
