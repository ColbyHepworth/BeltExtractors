using HarmonyLib;
using System.Reflection;
using Verse;

namespace BeltExtractors
{
    public class BeltExtractorsMod : Mod
    {
        public static Harmony HarmonyInstance;

        public BeltExtractorsMod(ModContentPack content) : base(content) { }
    }

    [StaticConstructorOnStartup]
    internal static class BeltExtractorsInit
    {
        static BeltExtractorsInit()
        {
            BeltExtractorsMod.HarmonyInstance = new Harmony("com.groovytaco.beltextractors");
            BeltExtractorsMod.HarmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
