using ABI.CCK.Components;
using ABI_RC.Core.Player;
using HarmonyLib;
using OpenGloves_Unity.Data;
using OpenGloves_Unity.Extensions;
using OpenGloves_Unity.Logging;

namespace ChilloutFfb.Patches
{
    [HarmonyPatch(typeof(CVRPickupObject), nameof(CVRPickupObject.Drop))]
    public class DropPatch
    {
        public static void Postfix(CVRPickupObject __instance)
        {
            var link = Mod.HandednessFromBool(__instance._controllerRay.hand).SharedLinkFromHandedness();
            link.Relax();

            Mod.Log.Info($"Relaxed FFB for {__instance.name} pickup.");
        }
    }
}