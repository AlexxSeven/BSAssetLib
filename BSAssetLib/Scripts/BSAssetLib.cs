using System;
using System.Linq;
using UnityEngine;

namespace BSAssetLib.Scripts
{
    internal class BSAssetLib
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
            Shader.SetGlobalColor(BSAssetLib._colSaberL, colorScheme.saberAColor);
            Shader.SetGlobalColor(BSAssetLib._colSaberR, colorScheme.saberBColor);
            Shader.SetGlobalColor(BSAssetLib._colLight0, colorScheme.environmentColor0);
            Shader.SetGlobalColor(BSAssetLib._colLight1, colorScheme.environmentColor1);
            Shader.SetGlobalColor(BSAssetLib._colWall, colorScheme.obstaclesColor);

            if(colorScheme.supportsEnvironmentColorBoost)
            {
                Shader.SetGlobalColor(BSAssetLib._colBoost0, colorScheme.environmentColor0Boost);
                Shader.SetGlobalColor(BSAssetLib._colBoost1, colorScheme.environmentColor1Boost);
            }
            else
            {
                Shader.SetGlobalColor(BSAssetLib._colBoost0, colorScheme.environmentColor0);
                Shader.SetGlobalColor(BSAssetLib._colBoost1, colorScheme.environmentColor1);
            }
        }
    }
}
