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
            if (Mod.Settings.SimulationOverrideEnable)
            {
                object boxed = (object)__result; // special handling because WaterSpectrumParameters is a struct

                Traverse traverse = Traverse.Create(boxed);

                Vector4 patchSizes = traverse.Field("patchSizes").GetValue<Vector4>();
                patchSizes.x = Mod.Settings.Large0PatchSize;
                patchSizes.y = Mod.Settings.Large1PatchSize;
                patchSizes.z = Mod.Settings.RipplesPatchSize;
                traverse.Field("patchSizes").SetValue(patchSizes);

                Vector4 patchWindSpeed = traverse.Field("patchWindSpeed").GetValue<Vector4>();
                patchWindSpeed.x = Mod.Settings.Large0WindSpeed;
                patchWindSpeed.y = Mod.Settings.Large1WindSpeed;
                patchWindSpeed.z = Mod.Settings.RipplesWindSpeed;
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
            if (Mod.Settings.SimulationOverrideEnable)
            {
                object boxed = (object)__result; // special handling because WaterRenderingParameters is a struct

                Traverse traverse = Traverse.Create(boxed);

                Vector4 patchAmplitudeMultiplier = traverse.Field("patchAmplitudeMultiplier").GetValue<Vector4>();
                patchAmplitudeMultiplier.x = Mod.Settings.Large0AmplitudeMultiplier;
                patchAmplitudeMultiplier.y = Mod.Settings.Large1AmplitudeMultiplier;
                patchAmplitudeMultiplier.z = Mod.Settings.RipplesAmplitudeMultiplier;
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
                    instance.startSmoothness = Mod.Settings.StartSmoothness;
                    instance.endSmoothness = Mod.Settings.EndSmoothness;
                    if (Mod.Settings.CausticsUseRippleBand)
                    {
                        instance.causticsBand = 2;
                    }
                    else
                    {
                        instance.causticsBand = 1;
                    }
                    
                    instance.absorptionDistance = Mod.Settings.AbsorptionDistance;
                    instance.refractionColor.r = Mod.Settings.RefractionColorR;
                    instance.refractionColor.g = Mod.Settings.RefractionColorG;
                    instance.refractionColor.b = Mod.Settings.RefractionColorB;
                    instance.scatteringColor.r = Mod.Settings.ScatteringColorR;
                    instance.scatteringColor.g = Mod.Settings.ScatteringColorG;
                    instance.scatteringColor.b = Mod.Settings.ScatteringColorB;
                    instance.causticsIntensity = Mod.Settings.CausticsIntensity;
                    instance.virtualPlaneDistance = Mod.Settings.CausticsVirtualPlaneDistance;
                }
            }
        }
    }
}