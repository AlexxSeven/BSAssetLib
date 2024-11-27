using System;
using System.Linq;
using UnityEngine;

namespace AssetLib.Scripts
{
    internal class AssetLib
    {
        private static readonly int _colSaberL = Shader.PropertyToID("_ColSaberL");
        private static readonly int _colSaberR = Shader.PropertyToID("_ColSaberR");
        private static readonly int _colLight0 = Shader.PropertyToID("_ColLight0");
        private static readonly int _colLight1 = Shader.PropertyToID("_ColLight1");
        private static readonly int _colBoost0 = Shader.PropertyToID("_ColBoost0");
        private static readonly int _colBoost1 = Shader.PropertyToID("_ColBoost1");
        private static readonly int _colWall = Shader.PropertyToID("_ColWall");
        internal void UpdateColorScheme(ColorScheme colorScheme)
        {
            Shader.SetGlobalColor(AssetLib._colSaberL, colorScheme.saberAColor);
            Shader.SetGlobalColor(AssetLib._colSaberR, colorScheme.saberBColor);
            Shader.SetGlobalColor(AssetLib._colLight0, colorScheme.environmentColor0);
            Shader.SetGlobalColor(AssetLib._colLight1, colorScheme.environmentColor1);
            Shader.SetGlobalColor(AssetLib._colWall, colorScheme.obstaclesColor);

            if(colorScheme.supportsEnvironmentColorBoost)
            {
                Shader.SetGlobalColor(AssetLib._colBoost0, colorScheme.environmentColor0Boost);
                Shader.SetGlobalColor(AssetLib._colBoost1, colorScheme.environmentColor1Boost);
            }
            else
            {
                Shader.SetGlobalColor(AssetLib._colBoost0, colorScheme.environmentColor0);
                Shader.SetGlobalColor(AssetLib._colBoost1, colorScheme.environmentColor1);
            }
        }
    }
}
