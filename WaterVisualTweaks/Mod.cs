using Colossal.IO.AssetDatabase;
using Colossal.Logging;
using Game;
using Game.Modding;
using Game.SceneFlow;
using HarmonyLib;

namespace WaterVisualTweaksMod
{
    public class Mod : IMod
    {
        public static ILog log = LogManager.GetLogger($"{nameof(WaterVisualTweaksMod)}").SetShowsErrorsInUI(false);

        private Harmony m_Harmony;

        /// <summary>
        /// Gets the static reference to the settings.
        /// </summary>
        public static WaterVisualTweaksSettings Settings
        {
            get;
            private set;
        }

        public void OnLoad(UpdateSystem updateSystem)
        {   
            if (GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset))
                log.Info($"{nameof(WaterVisualTweaksMod)}.{nameof(OnLoad)} Current mod asset at {asset.path}");

            Settings = new WaterVisualTweaksSettings(this);
            Settings.RegisterInOptionsUI();
            GameManager.instance.localizationManager.AddSource("en-US", new LocaleEN(Settings));
            AssetDatabase.global.LoadSettings(nameof(WaterVisualTweaksMod), Settings, new WaterVisualTweaksSettings(this));

            log.Info($"{nameof(WaterVisualTweaksMod)}.{nameof(OnLoad)} Injecting Harmony Patches.");
            m_Harmony = new Harmony("WaterVisualTweaksModHarmony");
            m_Harmony.PatchAll();
        }

        public void OnDispose()
        {
            log.Info($"{nameof(WaterVisualTweaksMod)}.{nameof(OnDispose)}");
            if (Settings != null)
            {
                Settings.UnregisterInOptionsUI();
                Settings = null;
            }
            m_Harmony.UnpatchAll();
        }
    }
}
