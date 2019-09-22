using Harmony;
using UnityEngine;


namespace BasicLadderMod
{
    // 25% increased up/down climbing speed

    [HarmonyPatch(typeof(LadderConfig), "ConfigureBuildingTemplate")]
    public class LadderConfig_ConfigureBuildingTemplate_Patch
    {
        public static void Postfix(GameObject go)
        {
            Ladder ladder = EntityTemplateExtensions.AddOrGet<Ladder>(go);
            ladder.upwardsMovementSpeedMultiplier = 1.25f;
            ladder.downwardsMovementSpeedMultiplier = 1.25f;
        }
    }


    // Construction materials changed to refined metals

    [HarmonyPatch(typeof(LadderConfig), "CreateBuildingDef")]
    public class LadderConfig_CreateBuildingDef_Patch
    {
        public static void Postfix(LadderConfig __instance, BuildingDef __result)
        {
            __result.MaterialCategory = new string[]{"RefinedMetal"};
        }
    }


}