using System;
using System.Linq;
using BSAssetLib.Providers;
using Zenject;

namespace BSAssetLib.Installers
{
    internal class BSAssetLibMenuInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MenuProvider>().AsSingle();
        }
    }
}
