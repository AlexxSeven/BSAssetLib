using System;
using System.Linq;
using BSAssetLib.Providers;
using JetBrains.Annotations;
using Zenject;

namespace BSAssetLib.Installers
{
    internal class BSAssetLibAppInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Scripts.BSAssetLib>().AsSingle();
        }
    }
}
