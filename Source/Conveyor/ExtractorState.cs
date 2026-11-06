using System.Collections.Generic;
using RimWorld;
using VanillaFurnitureExpandedFactory;

namespace BeltExtractors
{
    internal static class ExtractorState
    {
        private static readonly Dictionary<Building_Conveyor, Building_Storage> Extractors =
            new Dictionary<Building_Conveyor, Building_Storage>();

        internal static bool HasStorageInput(Building_Conveyor conveyor) => Extractors.ContainsKey(conveyor);

        internal static Building_Storage GetStorage(Building_Conveyor conveyor)
        {
            Extractors.TryGetValue(conveyor, out Building_Storage storage);
            return storage;
        }

        internal static void Set(Building_Conveyor conveyor, Building_Storage storage)
        {
            if (storage != null)
                Extractors[conveyor] = storage;
            else
                Extractors.Remove(conveyor);
        }

        internal static void Remove(Building_Conveyor conveyor) => Extractors.Remove(conveyor);
    }
}
