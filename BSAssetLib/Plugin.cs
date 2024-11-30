
using System;
using System.Reflection;
using IPA;
using IPALogger = IPA.Logging.Logger;
using SiraUtil.Zenject;
using BSAssetLib.Installers;

namespace BSAssetLib
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    internal class Plugin
    {
        [Init]
        public Plugin(IPALogger logger, Zenjector zenjector)
        {
            Log = logger;
            zenjector.Install<BSAssetLibMenuInstaller>(Location.Menu);
            zenjector.Install<BSAssetLibAppInstaller>(Location.App);
            zenjector.Install<BSAssetLibPlayerInstaller>(Location.Player);
        }

        public static IPALogger Log { get; set; } = null!;
    }
}
