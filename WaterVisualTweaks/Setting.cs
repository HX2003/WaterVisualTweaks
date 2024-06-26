﻿using Colossal;
using Colossal.IO.AssetDatabase;
using Game.Modding;
using Game.Settings;
using Game.UI;
using System.Collections.Generic;

namespace WaterVisualTweaksMod
{
    [FileLocation(nameof(WaterVisualTweaksMod))]
    [SettingsUIGroupOrder(kPresetsGroup, kSimParamsGroup, kMatParamsGroup, kCausticsParamsGroup)]
    [SettingsUIShowGroupName(kPresetsGroup, kSimParamsGroup, kMatParamsGroup, kCausticsParamsGroup)]
    public class WaterVisualTweaksSettings : ModSetting
    {
        public const string kSection = "Main";

        public const string kPresetsGroup = "Presets";
        public const string kSimParamsGroup = "Simulation Parameters";
        public const string kMatParamsGroup = "Material Parameters";
        public const string kCausticsParamsGroup = "Caustics Parameters";

        public WaterVisualTweaksSettings(IMod mod) : base(mod)
        {
            SetDefaults();
        }

        [SettingsUIButton]
        [SettingsUIConfirmation]
        [SettingsUISection(kSection, kPresetsGroup)]
        public bool PresetDefault
        {
            set
            {
                SetDefaults();
            }
        }

        [SettingsUISection(kSection, kSimParamsGroup)]
        public bool SimulationOverrideEnable { get; set; }

        [SettingsUISlider(min = 0.0f, max = 5.0f, step = 0.1f, scalarMultiplier = 1.0f, unit = Unit.kFloatSingleFraction)]
        [SettingsUISection(kSection, kSimParamsGroup)]
        public float RipplesWindSpeed { get; set; }

        [SettingsUISlider(min = 0.0f, max = 25.0f, step = 0.1f, scalarMultiplier = 1.0f, unit = Unit.kFloatSingleFraction)]
        [SettingsUISection(kSection, kSimParamsGroup)]
        public float Large1WindSpeed { get; set; }

        [SettingsUISlider(min = 0.0f, max = 100.0f, step = 1.0f, scalarMultiplier = 1.0f, unit = Unit.kFloatSingleFraction)]
        [SettingsUISection(kSection, kSimParamsGroup)]
        public float Large0WindSpeed { get; set; }

        [SettingsUISlider(min = 1.0f, max = 50.0f, step = 1.0f, scalarMultiplier = 1.0f, unit = Unit.kFloatSingleFraction)]
        [SettingsUISection(kSection, kSimParamsGroup)]
        public float RipplesPatchSize { get; set; }

        [SettingsUISlider(min = 10.0f, max = 500.0f, step = 10.0f, scalarMultiplier = 1.0f, unit = Unit.kFloatSingleFraction)]
        [SettingsUISection(kSection, kSimParamsGroup)]
        public float Large1PatchSize { get; set; }

        [SettingsUISlider(min = 100.0f, max = 2500.0f, step = 25.0f, scalarMultiplier = 1.0f, unit = Unit.kFloatSingleFraction)]
        [SettingsUISection(kSection, kSimParamsGroup)]
        public float Large0PatchSize { get; set; }

        [SettingsUISlider(min = 0.0f, max = 1.0f, step = 0.01f, scalarMultiplier = 1.0f, unit = Unit.kFloatTwoFractions)]
        [SettingsUISection(kSection, kSimParamsGroup)]
        public float RipplesAmplitudeMultiplier { get; set; }

        [SettingsUISlider(min = 0.0f, max = 1.0f, step = 0.01f, scalarMultiplier = 1.0f, unit = Unit.kFloatTwoFractions)]
        [SettingsUISection(kSection, kSimParamsGroup)]
        public float Large1AmplitudeMultiplier { get; set; }

        [SettingsUISlider(min = 0.0f, max = 1.0f, step = 0.01f, scalarMultiplier = 1.0f, unit = Unit.kFloatTwoFractions)]
        [SettingsUISection(kSection, kSimParamsGroup)]
        public float Large0AmplitudeMultiplier { get; set; }

        [SettingsUISlider(min = 0.0f, max = 1.0f, step = 0.01f, scalarMultiplier = 1.0f, unit = Unit.kFloatTwoFractions)]
        [SettingsUISection(kSection, kMatParamsGroup)]
        public float StartSmoothness { get; set; }

        [SettingsUISlider(min = 0.0f, max = 1.0f, step = 0.01f, scalarMultiplier = 1.0f, unit = Unit.kFloatTwoFractions)]
        [SettingsUISection(kSection, kMatParamsGroup)]
        public float EndSmoothness { get; set; }

        [SettingsUISlider(min = 0.0f, max = 25.0f, step = 0.1f, scalarMultiplier = 1.0f, unit = Unit.kFloatSingleFraction)]
        [SettingsUISection(kSection, kMatParamsGroup)]
        public float AbsorptionDistance { get; set; }

        [SettingsUISlider(min = 0.0f, max = 1.0f, step = 0.01f, scalarMultiplier = 1.0f, unit = Unit.kFloatTwoFractions)]
        [SettingsUISection(kSection, kMatParamsGroup)]
        public float RefractionColorR { get; set; }

        [SettingsUISlider(min = 0.0f, max = 1.0f, step = 0.01f, scalarMultiplier = 1.0f, unit = Unit.kFloatTwoFractions)]
        [SettingsUISection(kSection, kMatParamsGroup)]
        public float RefractionColorG { get; set; }

        [SettingsUISlider(min = 0.0f, max = 1.0f, step = 0.01f, scalarMultiplier = 1.0f, unit = Unit.kFloatTwoFractions)]
        [SettingsUISection(kSection, kMatParamsGroup)]
        public float RefractionColorB { get; set; }

        [SettingsUISlider(min = 0.0f, max = 1.0f, step = 0.01f, scalarMultiplier = 1.0f, unit = Unit.kFloatTwoFractions)]
        [SettingsUISection(kSection, kMatParamsGroup)]
        public float ScatteringColorR { get; set; }

        [SettingsUISlider(min = 0.0f, max = 1.0f, step = 0.01f, scalarMultiplier = 1.0f, unit = Unit.kFloatTwoFractions)]
        [SettingsUISection(kSection, kMatParamsGroup)]
        public float ScatteringColorG { get; set; }

        [SettingsUISlider(min = 0.0f, max = 1.0f, step = 0.01f, scalarMultiplier = 1.0f, unit = Unit.kFloatTwoFractions)]
        [SettingsUISection(kSection, kMatParamsGroup)]
        public float ScatteringColorB { get; set; }

        [SettingsUISection(kSection, kCausticsParamsGroup)]
        public bool CausticsUseRippleBand { get; set; }

        [SettingsUISlider(min = 0.0f, max = 1.0f, step = 0.01f, scalarMultiplier = 1.0f, unit = Unit.kFloatTwoFractions)]
        [SettingsUISection(kSection, kCausticsParamsGroup)]
        public float CausticsIntensity { get; set; }

        [SettingsUISlider(min = 0.0f, max = 25.0f, step = 0.1f, scalarMultiplier = 1.0f, unit = Unit.kFloatSingleFraction)]
        [SettingsUISection(kSection, kCausticsParamsGroup)]
        public float CausticsVirtualPlaneDistance { get; set; }

        public override void SetDefaults()
        {
            // Simulation parameters
            SimulationOverrideEnable = true;
            RipplesWindSpeed = 2.0f;
            Large1WindSpeed = 4.0f;
            Large0WindSpeed = 50.0f;
            RipplesPatchSize = 20.0f;
            Large1PatchSize = 250.0f;
            Large0PatchSize = 2000.0f;
            RipplesAmplitudeMultiplier = 1.0f;
            Large1AmplitudeMultiplier = 0.75f;
            Large0AmplitudeMultiplier = 0.12f;

            // Material parameters
            StartSmoothness = 0.95f;
            EndSmoothness = 0.9f;
            AbsorptionDistance = 8.0f;
            RefractionColorR = 0.1f;
            RefractionColorG = 0.5f;
            RefractionColorB = 0.5f;
            ScatteringColorR = 0.0f;
            ScatteringColorG = 0.4f;
            ScatteringColorB = 0.4f;

            // Caustics parameters
            CausticsUseRippleBand = true;
            CausticsIntensity = 0.5f;
            CausticsVirtualPlaneDistance = 5.0f;
        }
    }

    public class LocaleEN : IDictionarySource
    {
        private readonly WaterVisualTweaksSettings m_Setting;
        public LocaleEN(WaterVisualTweaksSettings setting)
        {
            m_Setting = setting;
        }
        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Water Visual Tweaks" },
                { m_Setting.GetOptionTabLocaleID(WaterVisualTweaksSettings.kSection), "Main" },


                { m_Setting.GetOptionGroupLocaleID(WaterVisualTweaksSettings.kPresetsGroup), "Presets" },
                { m_Setting.GetOptionGroupLocaleID(WaterVisualTweaksSettings.kSimParamsGroup), "Simulation Parameters" },
                { m_Setting.GetOptionGroupLocaleID(WaterVisualTweaksSettings.kMatParamsGroup), "Material Parameters" },
                { m_Setting.GetOptionGroupLocaleID(WaterVisualTweaksSettings.kCausticsParamsGroup), "Caustics Parameters" },

                { m_Setting.GetOptionLabelLocaleID(nameof(WaterVisualTweaksSettings.PresetDefault)), "Reset to default" },
                { m_Setting.GetOptionDescLocaleID(nameof(WaterVisualTweaksSettings.PresetDefault)), "Applies this preset to your settings. Presets may be updated by the mod creator but they will be not applied automatically." },
                { m_Setting.GetOptionWarningLocaleID(nameof(WaterVisualTweaksSettings.PresetDefault)), "Are you sure you want to apply this preset? Your existing settings will be overriden." },

                { m_Setting.GetOptionLabelLocaleID(nameof(WaterVisualTweaksSettings.SimulationOverrideEnable)), "Enable" },
                { m_Setting.GetOptionDescLocaleID(nameof(WaterVisualTweaksSettings.SimulationOverrideEnable)), "Override in-game values." },

                { m_Setting.GetOptionLabelLocaleID(nameof(WaterVisualTweaksSettings.RipplesWindSpeed)), "Small Ripples Wind Speed" },
                { m_Setting.GetOptionDescLocaleID(nameof(WaterVisualTweaksSettings.RipplesWindSpeed)), "Size and shape of small ripples." },

                { m_Setting.GetOptionLabelLocaleID(nameof(WaterVisualTweaksSettings.Large1WindSpeed)), "Medium Wind Speed" },
                { m_Setting.GetOptionDescLocaleID(nameof(WaterVisualTweaksSettings.Large1WindSpeed)), "Size and shape of medium swell." },

                { m_Setting.GetOptionLabelLocaleID(nameof(WaterVisualTweaksSettings.Large0WindSpeed)), "Large Wind Speed" },
                { m_Setting.GetOptionDescLocaleID(nameof(WaterVisualTweaksSettings.Large0WindSpeed)), "Size and shape of large swell." },

                { m_Setting.GetOptionLabelLocaleID(nameof(WaterVisualTweaksSettings.RipplesPatchSize)), "Small Ripples Patch Size" },
                { m_Setting.GetOptionDescLocaleID(nameof(WaterVisualTweaksSettings.RipplesPatchSize)), "Size of the water patch. Higher values result in less visible repetition, but less effective resolution." },

                { m_Setting.GetOptionLabelLocaleID(nameof(WaterVisualTweaksSettings.Large1PatchSize)), "Medium Patch Size" },
                { m_Setting.GetOptionDescLocaleID(nameof(WaterVisualTweaksSettings.Large1PatchSize)), "Size of the water patch. Higher values result in less visible repetition, but less effective resolution." },

                { m_Setting.GetOptionLabelLocaleID(nameof(WaterVisualTweaksSettings.Large0PatchSize)), "Large Patch Size" },
                { m_Setting.GetOptionDescLocaleID(nameof(WaterVisualTweaksSettings.Large0PatchSize)), "Size of the water patch. Higher values result in less visible repetition, but less effective resolution." },

                { m_Setting.GetOptionLabelLocaleID(nameof(WaterVisualTweaksSettings.RipplesAmplitudeMultiplier)), "Small Ripples Amplitude Multiplier" },
                { m_Setting.GetOptionDescLocaleID(nameof(WaterVisualTweaksSettings.RipplesAmplitudeMultiplier)), "Multiplies displacement by this amount." },

                { m_Setting.GetOptionLabelLocaleID(nameof(WaterVisualTweaksSettings.Large1AmplitudeMultiplier)), "Medium Amplitude Multiplier" },
                { m_Setting.GetOptionDescLocaleID(nameof(WaterVisualTweaksSettings.Large1AmplitudeMultiplier)), "Multiplies displacement by this amount." },

                { m_Setting.GetOptionLabelLocaleID(nameof(WaterVisualTweaksSettings.Large0AmplitudeMultiplier)), "Large Amplitude Multiplier" },
                { m_Setting.GetOptionDescLocaleID(nameof(WaterVisualTweaksSettings.Large0AmplitudeMultiplier)), "Multiplies displacement by this amount." },

                { m_Setting.GetOptionLabelLocaleID(nameof(WaterVisualTweaksSettings.StartSmoothness)), "Start Smoothness" },
                { m_Setting.GetOptionDescLocaleID(nameof(WaterVisualTweaksSettings.StartSmoothness)), "Water material smoothness." },

                { m_Setting.GetOptionLabelLocaleID(nameof(WaterVisualTweaksSettings.EndSmoothness)), "End Smoothness" },
                { m_Setting.GetOptionDescLocaleID(nameof(WaterVisualTweaksSettings.EndSmoothness)), "Water material smoothness." },

                { m_Setting.GetOptionLabelLocaleID(nameof(WaterVisualTweaksSettings.AbsorptionDistance)), "Absorption Distance" },
                { m_Setting.GetOptionDescLocaleID(nameof(WaterVisualTweaksSettings.AbsorptionDistance)), "Approximate distance light can pass through water; water clarity." },

                { m_Setting.GetOptionLabelLocaleID(nameof(WaterVisualTweaksSettings.RefractionColorR)), "Refraction Color [Red]" },
                { m_Setting.GetOptionDescLocaleID(nameof(WaterVisualTweaksSettings.RefractionColorR)), "Color of under-water refraction, prominent near the coast, red channel." },

                { m_Setting.GetOptionLabelLocaleID(nameof(WaterVisualTweaksSettings.RefractionColorG)), "Refraction Color [Green]" },
                { m_Setting.GetOptionDescLocaleID(nameof(WaterVisualTweaksSettings.RefractionColorG)), "Color of under-water refraction, prominent near the coast, green channel." },

                { m_Setting.GetOptionLabelLocaleID(nameof(WaterVisualTweaksSettings.RefractionColorB)), "Refraction Color [Blue]" },
                { m_Setting.GetOptionDescLocaleID(nameof(WaterVisualTweaksSettings.RefractionColorB)), "Color of under-water refraction, prominent near the coast, blue channel" },

                { m_Setting.GetOptionLabelLocaleID(nameof(WaterVisualTweaksSettings.ScatteringColorR)), "Scattering Color [Red]" },
                { m_Setting.GetOptionDescLocaleID(nameof(WaterVisualTweaksSettings.ScatteringColorR)), "Water material scattering color, red channel." },

                { m_Setting.GetOptionLabelLocaleID(nameof(WaterVisualTweaksSettings.ScatteringColorG)), "Scattering Color [Green]" },
                { m_Setting.GetOptionDescLocaleID(nameof(WaterVisualTweaksSettings.ScatteringColorG)), "Water material scattering color, green channel." },

                { m_Setting.GetOptionLabelLocaleID(nameof(WaterVisualTweaksSettings.ScatteringColorB)), "Scattering Color [Blue]" },
                { m_Setting.GetOptionDescLocaleID(nameof(WaterVisualTweaksSettings.ScatteringColorB)), "Water material scattering color, blue channel." },

                { m_Setting.GetOptionLabelLocaleID(nameof(WaterVisualTweaksSettings.CausticsUseRippleBand)), "Use Ripples for Caustics" },
                { m_Setting.GetOptionDescLocaleID(nameof(WaterVisualTweaksSettings.CausticsUseRippleBand)), "When enabled the ripple band is used for caustics, otherwise the medium band is used for caustics." },

                { m_Setting.GetOptionLabelLocaleID(nameof(WaterVisualTweaksSettings.CausticsIntensity)), "Intensity" },
                { m_Setting.GetOptionDescLocaleID(nameof(WaterVisualTweaksSettings.CausticsIntensity)), "Intensity of caustics." },

                { m_Setting.GetOptionLabelLocaleID(nameof(WaterVisualTweaksSettings.CausticsVirtualPlaneDistance)), "Sharpness" },
                { m_Setting.GetOptionDescLocaleID(nameof(WaterVisualTweaksSettings.CausticsVirtualPlaneDistance)), "Sharpness of caustics." },
                 
            };
        }

        public void Unload()
        {

        }
    }
}
