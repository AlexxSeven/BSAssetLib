using System;
using System.Linq;
using Zenject;

namespace BSAssetLib.Providers
{
    internal class GameProvider : IInitializable
    {
        private readonly Scripts.BSAssetLib _bsAssetLib;
        private readonly ColorScheme _colorScheme;

        private GameProvider(Scripts.BSAssetLib bsAssetLib, ColorScheme colorScheme)
        {
            _bsAssetLib = bsAssetLib;
            _colorScheme = colorScheme;
        }

        public void Initialize ()
        {
            _bsAssetLib.UpdateColorScheme(_colorScheme);
        }
    }
}
