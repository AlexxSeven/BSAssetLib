using System;
using System.Linq;
using Zenject;

namespace AssetLib.Providers
{
    internal class GameProvider : IInitializable
    {
        private readonly Scripts.AssetLib _assetLib;
        private readonly ColorScheme _colorScheme;

        public void Initialize ()
        {
            _assetLib.UpdateColorScheme(_colorScheme);
        }
    }
}
