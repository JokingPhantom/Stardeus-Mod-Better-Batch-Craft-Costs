using HarmonyLib;
using Game.Utils;
using UnityEngine;

public sealed class BatchCraftPatcher {
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    private static void Register() {
        var harmony = new Harmony("com.BatchCraftPatcher.patch");
        harmony.PatchAll();
    }
}

// Annotations to inform Harmony Lib of the target method to patch
[HarmonyPatch(typeof(Equations))]
class BatchCraftPatch
{
    [HarmonyPrefix]
    [HarmonyPatch("BatchSizeCost")]
    static bool Prefix(ref float __result, int bs)
    {
        __result = (float) ( bs * 0.1 + 0.9);
        return false;
    }

    // public static float OriginalBatchSizeCost(int bs)
    // {
    //   if (bs < 2)
    //     return 1f;
    //   float num = 1.01053f;
    //   return (float) (-0.01052630040794611 * (double) bs) + num;
    // }
}
