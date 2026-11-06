using HarmonyLib;
using RimWorld;
using VanillaFurnitureExpandedFactory;
using Verse;

namespace BeltExtractors
{
    [HarmonyPatch(typeof(Building_Conveyor), "ProcessMovement")]
    public static class BuildingConveyorProcessMovementPatch
    {
        public static void Postfix(Building_Conveyor __instance, ref float ___lastItemProgress)
        {
            Building_Storage storage = ExtractorState.GetStorage(__instance);
            if (storage == null)
                return;
            if (__instance.innerContainer.Count > 0)
                return;
            if (__instance.state == Building_Conveyor.ConveyorState.Waiting)
                return;

            Thing item = null;
            foreach (IntVec3 cell in storage.AllSlotCells())
            {
                foreach (Thing t in cell.GetThingList(__instance.Map))
                {
                    if (t.def.category == ThingCategory.Item)
                    {
                        item = t;
                        break;
                    }
                }
                if (item != null) break;
            }

            if (item == null)
                return;

            Thing taken = item.SplitOff(item.stackCount);
            if (taken.Spawned) taken.DeSpawn();
            __instance.innerContainer.TryAdd(taken);
            __instance.state = Building_Conveyor.ConveyorState.Moving;
            __instance.itemProgress = -1f;
            ___lastItemProgress = -1f;
        }
    }
}
