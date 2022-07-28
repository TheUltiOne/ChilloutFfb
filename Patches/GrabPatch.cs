using ABI.CCK.Components;
using ABI_RC.Core.Player;
using HarmonyLib;
using OpenGloves_Unity.Data;
using OpenGloves_Unity.Extensions;
using OpenGloves_Unity.Logging;

namespace ChilloutFfb.Patches
{
    [HarmonyPatch(typeof(CVRPickupObject), nameof(CVRPickupObject.Grab))]
    public class GrabPatch
    {
        public static void Postfix(CVRPickupObject __instance, PlayerAvatarMovementData ____playerAvatarMovementData)
        {
            if (__instance.isTeleGrabbed)
                return;

            var link = Mod.HandednessFromBool(__instance._controllerRay.hand).SharedLinkFromHandedness();
            var input = link.Handedness == Handedness.Left ?
                new Input((short)____playerAvatarMovementData.LeftThumbCurl, (short)____playerAvatarMovementData.LeftIndexCurl, (short)____playerAvatarMovementData.LeftMiddleCurl, (short)____playerAvatarMovementData.LeftRingCurl, (short)____playerAvatarMovementData.LeftPinkyCurl) : 
                new Input((short) ____playerAvatarMovementData.RightThumbCurl, (short) ____playerAvatarMovementData.RightIndexCurl, (short) ____playerAvatarMovementData.RightMiddleCurl, (short) ____playerAvatarMovementData.RightRingCurl, (short) ____playerAvatarMovementData.RightPinkyCurl);

            link.WriteInput(input);
            Mod.Log.Info($"Started FFB for {__instance.name} pickup.");
        }
    }
}