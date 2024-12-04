using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiraUtil.Affinity;
using UnityEngine;

#nullable enable
namespace BSAssetLib.Providers
{
    internal class MenuProvider : IAffinity
    {
        private static ColorScheme? _menuColors;

        private readonly Scripts.BSAssetLib _bsAssetLib;
        private readonly PlayerDataModel _playerDataModel;

        private MenuProvider(Scripts.BSAssetLib bsAssetLib, PlayerDataModel playerDataModel)
        {
            _bsAssetLib = bsAssetLib;
            _playerDataModel = playerDataModel;
            UpdateColorScheme();
        }

        private static ColorScheme MenuColors
        {
            get
            {
                if (_menuColors == null)
                {
                    _menuColors = ((IEnumerable<ColorManagerInstaller>)Resources.FindObjectsOfTypeAll<ColorManagerInstaller>()).First<ColorManagerInstaller>()._menuColorScheme.colorScheme;
                }
                return _menuColors;
            }
        }

        [AffinityPostfix]
        [AffinityPatch(
            typeof(ColorsOverrideSettingsPanelController),
            "HandleOverrideColorsToggleValueChanged")]
        [AffinityPatch(
            typeof(ColorsOverrideSettingsPanelController),
            "HandleEditColorSchemeControllerDidChangeColorScheme")]
        [AffinityPatch(
            typeof(ColorsOverrideSettingsPanelController),
            "HandleDropDownDidSelectCellWithIdx")]
        private void UpdateColorScheme()
        {
            _bsAssetLib.UpdateColorScheme(_playerDataModel.playerData.colorSchemesSettings.GetOverrideColorScheme() ?? MenuColors);
        }
    }
}
