using HarmonyLib;
using VanillaFurnitureExpandedFactory;

namespace BeltExtractors
{
    [HarmonyPatch(typeof(Building_Conveyor), nameof(Building_Conveyor.DeSpawn))]
    public static class BuildingConveyorDeSpawnPatch
    {
        public static void Postfix(Building_Conveyor __instance)
        {
            ExtractorState.Remove(__instance);
        }
    }
}
