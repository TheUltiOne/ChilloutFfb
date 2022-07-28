using System;
using MelonLoader;
using OpenGloves_Unity.Data;
using OpenGloves_Unity.Logging;
using Harmony = HarmonyLib.Harmony;

namespace ChilloutFfb
{
    public class Mod : MelonMod
    {
        public static Log Log { get; set; }
        public HarmonyLib.Harmony Harmony { get; set; }

        public override void OnApplicationStart()
        {
            base.OnApplicationStart();
            Log = new Log("ChilloutVR Mods", "ffb.log");

            Harmony = new HarmonyLib.Harmony($"com.theultione.cvr.ffb.{DateTime.Now.Ticks}");
            Harmony.PatchAll();
        }

        public override void OnApplicationQuit()
        {
            Harmony.UnpatchSelf();
            Harmony = null;
        }

        public static Handedness HandednessFromBool(bool hand)
            => hand ? Handedness.Left : Handedness.Right;
    }
}