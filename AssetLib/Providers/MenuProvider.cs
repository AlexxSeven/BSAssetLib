using System;
using System.Linq;
using SiraUtil.Affinity;
using UnityEngine;

namespace AssetLib.Providers
{
    internal class MenuProvider : IAffinity
    {
        private readonly Scripts.AssetLib _assetLib;
        private readonly PlayerDataModel _playerDataModel;

        private MenuProvider(Scripts.AssetLib assetLib, PlayerDataModel playerDataModel)
        {
            _assetLib = assetLib;
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
            _assetLib.UpdateColorScheme(_playerDataModel.playerData.colorSchemesSettings.GetOverrideColorScheme());
        }
    }
}
