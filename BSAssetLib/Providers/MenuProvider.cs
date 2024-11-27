using System;
using System.Linq;
using SiraUtil.Affinity;
using UnityEngine;

namespace BSAssetLib.Providers
{
    internal class MenuProvider : IAffinity
    {
        private readonly Scripts.BSAssetLib _bsAssetLib;
        private readonly PlayerDataModel _playerDataModel;

        private MenuProvider(Scripts.BSAssetLib bsAssetLib, PlayerDataModel playerDataModel)
        {
            _bsAssetLib = bsAssetLib;
            _playerDataModel = playerDataModel;
            UpdateColorScheme();
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
            _bsAssetLib.UpdateColorScheme(_playerDataModel.playerData.colorSchemesSettings.GetOverrideColorScheme());
        }
    }
}
