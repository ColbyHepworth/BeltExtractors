using HarmonyLib;
using PipeSystem;
using RimWorld;
using VanillaFurnitureExpandedFactory;
using Verse;

namespace BeltExtractors
{
    [HarmonyPatch(typeof(Building_Conveyor), "InvalidateCache")]
    public static class BuildingConveyorInvalidateCachePatch
    {
        public static void Postfix(Building_Conveyor __instance, ref bool ___cachedShowItems)
        {
            IntVec3 behindCell = __instance.Position + __instance.Rotation.Opposite.FacingCell;

            if (!behindCell.InBounds(__instance.Map))
            {
                ExtractorState.Set(__instance, null);
                return;
            }

            Building_Storage validStorage = null;
            foreach (Thing t in behindCell.GetThingList(__instance.Map))
            {
                if (t is Building_Storage storage
                    && !(storage is Building_FactoryHopper)
                    && storage.def.GetModExtension<FactoryHopperExtension>()?.isfactoryHopper != true)
                {
                    validStorage = storage;
                    break;
                }
            }

            ExtractorState.Set(__instance, validStorage);
            if (validStorage != null)
                ___cachedShowItems = false;
        }
    }
}
