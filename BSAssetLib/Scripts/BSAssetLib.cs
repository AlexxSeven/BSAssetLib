using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BSAssetLib.Scripts
{
    internal class BSAssetLib
    {

        private ColorScheme _beatmapColorScheme;
        private readonly ColorSchemesSettings _colorSchemesSettings;

        private static readonly int _colSaberL = Shader.PropertyToID("_ColSaberL");
        private static readonly int _colSaberR = Shader.PropertyToID("_ColSaberR");
        private static readonly int _colLight0 = Shader.PropertyToID("_ColLight0");
        private static readonly int _colLight1 = Shader.PropertyToID("_ColLight1");
        private static readonly int _colBoost0 = Shader.PropertyToID("_ColBoost0");
        private static readonly int _colBoost1 = Shader.PropertyToID("_ColBoost1");
        private static readonly int _colWall = Shader.PropertyToID("_ColWall");
        
        private BSAssetLib(ColorSchemesSettings colorSchemesSettings)
        {
            _colorSchemesSettings = colorSchemesSettings;
            _beatmapColorScheme = ((IEnumerable<ColorManagerInstaller>)Resources.FindObjectsOfTypeAll<ColorManagerInstaller>()).First<ColorManagerInstaller>()._menuColorScheme.colorScheme;
        }

        internal void SetColorSchemeData(ColorScheme beatmapColorScheme, ColorScheme colorScheme)
        {
            _beatmapColorScheme = beatmapColorScheme;
            UpdateColorScheme(colorScheme);
        }

        internal void UpdateColorScheme(ColorScheme colorScheme)
        {
            Shader.SetGlobalColor(BSAssetLib._colSaberL, colorScheme.saberAColor);
            Shader.SetGlobalColor(BSAssetLib._colSaberR, colorScheme.saberBColor);
            Shader.SetGlobalColor(BSAssetLib._colWall, colorScheme.obstaclesColor);

            if (_colorSchemesSettings.ShouldOverrideLightshowColors() == false)
            {
                Shader.SetGlobalColor(BSAssetLib._colLight0, _beatmapColorScheme.environmentColor0);
                Shader.SetGlobalColor(BSAssetLib._colLight1, _beatmapColorScheme.environmentColor1);
                if (_beatmapColorScheme.environmentColor0Boost != Color.clear)
                {
                    Shader.SetGlobalColor(BSAssetLib._colBoost0, _beatmapColorScheme.environmentColor0Boost);
                    Shader.SetGlobalColor(BSAssetLib._colBoost1, _beatmapColorScheme.environmentColor1Boost);
                }
                else
                {
                    Shader.SetGlobalColor(BSAssetLib._colBoost0, _beatmapColorScheme.environmentColor0);
                    Shader.SetGlobalColor(BSAssetLib._colBoost1, _beatmapColorScheme.environmentColor1);
                }
            }
            else
            {
                Shader.SetGlobalColor(BSAssetLib._colLight0, colorScheme.environmentColor0);
                Shader.SetGlobalColor(BSAssetLib._colLight1, colorScheme.environmentColor1);
                if (colorScheme.environmentColor0Boost != Color.clear)
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
}
