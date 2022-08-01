using System;
using MelonLoader;
using OpenGloves_Unity.Data;
using OpenGloves_Unity.Logging;
using OpenGloves_Unity.Shared;
using Harmony = HarmonyLib.Harmony;

namespace ChilloutFfb
{
    public class Mod : MelonMod
    {
        public static Log Log { get; set; }

        public override void OnApplicationStart()
        {
            base.OnApplicationStart();
            Log = new Log("ChilloutVR Modding", "ffb.log");
        }

        public override void OnApplicationQuit()
        {
            SharedLinks.LeftLink.Relax();
            SharedLinks.RightLink.Relax();
        }

        public static Handedness HandednessFromBool(bool hand)
            => hand ? Handedness.Left : Handedness.Right;
    }
}