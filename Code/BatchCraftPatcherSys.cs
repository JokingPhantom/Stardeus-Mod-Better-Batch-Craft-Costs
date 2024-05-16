using HarmonyLib;
using Game.Utils;
using UnityEngine;
using Game.Systems;

namespace BetterBatchCraftCosts {
    public sealed class BatchCraftPatcherSys : GameSystem {
        // The convention is that all systems end with Sys, and SysId is equal to the class name
        public const string SysId = "BatchCraftPatcherSys";
        public override string Id => SysId;
        // If your system can work in sandbox too, set this to false
        public override bool SkipInSandbox => false;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void Register() {
            GameSystems.Register(SysId, () => new BatchCraftPatcherSys());

            var harmony = new Harmony("com.BetterBatchCraftCosts.patch");
            var original = typeof(Equations).GetMethod(nameof(Equations.BatchSizeHalfCost));
            var prefix = typeof(BatchCraftPatch).GetMethod(nameof(BatchCraftPatch.BatchSizeHalfCost));
            harmony.Patch(original, new HarmonyMethod(prefix));
        }

        public class BatchCraftPatch
        {
            public static bool BatchSizeHalfCost(ref float __result, int bs)
            {
                __result = (float) ( bs * 0.1 + 0.9);
                return false;
            }

            // public static float OriginalBatchSizeHalfCost(int bs)
            // {
            //     if (bs < 2)
            //         return 1f;
            //     float num1 = 1.99649f;
            //     float num2 = 0.0233918f;
            //     return (float) ((-0.019882999360561371 * (double) bs * (double) bs + (double) num1 * (double) bs + (double) num2) / 2.0);
            // }
        }
        protected override void OnInitialize() {
        }

        public override void Unload() {
        }
	}
}
