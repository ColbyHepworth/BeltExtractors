using HarmonyLib;
using UnityEngine;
using VanillaFurnitureExpandedFactory;
using Verse;

namespace BeltExtractors
{
    [HarmonyPatch(typeof(Building_Conveyor), "get_Graphic")]
    public static class BuildingConveyorGraphicPatch
    {
        public static void Postfix(Building_Conveyor __instance, ref Graphic __result, ref bool ___cachedIsSingleDirectional)
        {
            if (!ExtractorState.HasStorageInput(__instance))
                return;
            if (__instance.IsTurn || __instance.IsSplitter || __instance.IsMerger)
                return;

            ConveyorExtension ext = __instance.def.GetModExtension<ConveyorExtension>();
            if (ext == null || string.IsNullOrEmpty(ext.baseTexPath))
                return;

            __result = GraphicDatabase.Get<Graphic_Multi>(
                $"{ext.baseTexPath}/ConveyorExtractor",
                ShaderDatabase.Cutout,
                __instance.def.graphicData.drawSize,
                Color.white
            );
            ___cachedIsSingleDirectional = false;
        }
    }
}
