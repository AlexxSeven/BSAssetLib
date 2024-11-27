using System;
using System.Linq;
using AssetLib.Providers;
using JetBrains.Annotations;
using Zenject;

namespace AssetLib.Installers
{
    internal class AssetLibAppInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Scripts.AssetLib>().AsSingle();
        }
    }
}
