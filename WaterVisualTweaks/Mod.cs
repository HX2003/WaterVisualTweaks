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
        public Setting settings;

        private Harmony m_Harmony;

        /// <summary>
        /// Gets the static reference to the mod instance.
        /// </summary>
        public static Mod Instance
        {
            get;
            private set;
        }

        public void OnLoad(UpdateSystem updateSystem)
        {   
            Instance = this;

            if (GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset))
                log.Info($"{nameof(WaterVisualTweaksMod)}.{nameof(OnLoad)} Current mod asset at {asset.path}");

            settings = new Setting(this);
            settings.RegisterInOptionsUI();
            GameManager.instance.localizationManager.AddSource("en-US", new LocaleEN(settings));
            AssetDatabase.global.LoadSettings(nameof(WaterVisualTweaksMod), settings, new Setting(this));

            log.Info($"{nameof(WaterVisualTweaksMod)}.{nameof(OnLoad)} Injecting Harmony Patches.");
            m_Harmony = new Harmony("WaterVisualTweaksModHarmony");
            m_Harmony.PatchAll();
        }

        public void OnDispose()
        {
            log.Info($"{nameof(WaterVisualTweaksMod)}.{nameof(OnDispose)}");
            if (settings != null)
            {
                settings.UnregisterInOptionsUI();
                settings = null;
            }
            m_Harmony.UnpatchAll();
        }
    }
}
