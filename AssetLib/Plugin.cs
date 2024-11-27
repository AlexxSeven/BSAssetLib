
using System;
using System.Reflection;
using HarmonyLib;
using IPA;
using IPALogger = IPA.Logging.Logger;
using SiraUtil.Zenject;
using AssetLib.Installers;

namespace AssetLib
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    internal class Plugin
    {
        [Init]
        public Plugin(IPALogger logger, Zenjector zenjector)
        {
            Log = logger;
            zenjector.Install<AssetLibMenuInstaller>(Location.Menu);
            zenjector.Install<AssetLibAppInstaller>(Location.App);
            zenjector.Install<AssetLibPlayerInstaller>(Location.Player);
        }

        public static IPALogger Log { get; set; } = null!;
    }
}
