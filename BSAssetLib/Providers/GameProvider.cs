using System;
using System.Linq;
using Zenject;

namespace BSAssetLib.Providers
{
    internal class GameProvider : IInitializable
    {
        private readonly Scripts.BSAssetLib _bsAssetLib;
        private readonly ColorScheme _colorScheme;
        private readonly ColorScheme _beatmapColorScheme;

        private GameProvider(Scripts.BSAssetLib bsAssetLib, ColorScheme colorScheme, GameplayCoreSceneSetupData gameplayCoreSceneSetupData)
        {
            _bsAssetLib = bsAssetLib;
            _colorScheme = colorScheme;
            _beatmapColorScheme = gameplayCoreSceneSetupData.colorScheme;
        }

        public void Initialize ()
        {
            _bsAssetLib.SetColorSchemeData(_beatmapColorScheme, _colorScheme);
        }
    }
}
