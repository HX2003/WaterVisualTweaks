namespace WaterVisualTweaksMod.Patches
{
    using Game.Rendering;
    using HarmonyLib;
    using System.Collections.Generic;
    using System.Reflection;
    using UnityEngine;
    using UnityEngine.Rendering.HighDefinition;

    [HarmonyPatch(typeof(WaterSurface), "EvaluateSpectrumParams")]
    public class EvaluateSpectrumParams_Patch
    {
        public static void Postfix(ref WaterSpectrumParameters __result, WaterSurfaceType type)
        {
            if (Mod.Instance.settings.SimulationOverrideEnable)
            {
                object boxed = (object)__result; // special handling because WaterSpectrumParameters is a struct

                Traverse traverse = Traverse.Create(boxed);

                Vector4 patchSizes = traverse.Field("patchSizes").GetValue<Vector4>();
                patchSizes.x = Mod.Instance.settings.Large0PatchSize;
                patchSizes.y = Mod.Instance.settings.Large1PatchSize;
                patchSizes.z = Mod.Instance.settings.RipplesPatchSize;
                traverse.Field("patchSizes").SetValue(patchSizes);

                Vector4 patchWindSpeed = traverse.Field("patchWindSpeed").GetValue<Vector4>();
                patchWindSpeed.x = Mod.Instance.settings.Large0WindSpeed;
                patchWindSpeed.y = Mod.Instance.settings.Large1WindSpeed;
                patchWindSpeed.z = Mod.Instance.settings.RipplesWindSpeed;
                traverse.Field("patchWindSpeed").SetValue(patchWindSpeed);

                __result = (WaterSpectrumParameters)boxed;
            }
        }
    }

    [HarmonyPatch(typeof(WaterSurface), "EvaluateRenderingParams")]
    public class EvaluateRenderingParams_Patch
    {
        public static void Postfix(ref WaterRenderingParameters __result, WaterSurfaceType type)
        {
            if (Mod.Instance.settings.SimulationOverrideEnable)
            {
                object boxed = (object)__result; // special handling because WaterRenderingParameters is a struct

                Traverse traverse = Traverse.Create(boxed);

                Vector4 patchAmplitudeMultiplier = traverse.Field("patchAmplitudeMultiplier").GetValue<Vector4>();
                patchAmplitudeMultiplier.x = Mod.Instance.settings.Large0AmplitudeMultiplier;
                patchAmplitudeMultiplier.y = Mod.Instance.settings.Large1AmplitudeMultiplier;
                patchAmplitudeMultiplier.z = Mod.Instance.settings.RipplesAmplitudeMultiplier;
                traverse.Field("patchAmplitudeMultiplier").SetValue(patchAmplitudeMultiplier);

                __result = (WaterRenderingParameters)boxed;
            }
        }
    }

    [HarmonyPatch(typeof(WaterRenderSystem), "OnUpdate")]
    public class OnUpdate_Patch
    {
        // Is patching necessary?
        public static void Postfix()
        {
            FieldInfo fieldInfo = typeof(WaterSurface).GetField("instances", BindingFlags.NonPublic | BindingFlags.Static);
            if (fieldInfo != null)
            {
                HashSet<WaterSurface> instances = (HashSet<WaterSurface>)fieldInfo.GetValue(null);
                foreach (WaterSurface instance in instances)
                {
                    instance.startSmoothness = Mod.Instance.settings.StartSmoothness;
                    instance.endSmoothness = Mod.Instance.settings.EndSmoothness;
                    if (Mod.Instance.settings.CausticsUseRippleBand)
                    {
                        instance.causticsBand = 2;
                    }
                    else
                    {
                        instance.causticsBand = 1;
                    }
                    
                    instance.absorptionDistance = Mod.Instance.settings.AbsorptionDistance;
                    instance.refractionColor.r = Mod.Instance.settings.RefractionColorR;
                    instance.refractionColor.g = Mod.Instance.settings.RefractionColorG;
                    instance.refractionColor.b = Mod.Instance.settings.RefractionColorB;
                    instance.scatteringColor.r = Mod.Instance.settings.ScatteringColorR;
                    instance.scatteringColor.g = Mod.Instance.settings.ScatteringColorG;
                    instance.scatteringColor.b = Mod.Instance.settings.ScatteringColorB;
                    instance.causticsIntensity = Mod.Instance.settings.CausticsIntensity;
                    instance.virtualPlaneDistance = Mod.Instance.settings.CausticsVirtualPlaneDistance;
                }
            }
        }
    }
}