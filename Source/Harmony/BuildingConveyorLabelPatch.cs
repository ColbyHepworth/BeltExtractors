using HarmonyLib;
using VanillaFurnitureExpandedFactory;
using Verse;

namespace BeltExtractors
{
    [HarmonyPatch(typeof(Building_Conveyor), "get_Label")]
    public static class BuildingConveyorLabelPatch
    {
        public static void Postfix(Building_Conveyor __instance, ref string __result)
        {
            if (ExtractorState.HasStorageInput(__instance))
                __result = "BeltExtractors_ExtractorBelt".Translate();
        }
    }
}
