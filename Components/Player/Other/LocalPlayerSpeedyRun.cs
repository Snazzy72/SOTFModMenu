using TheForest;
using SOTFModMenu.Components.Utility;

namespace SOTFModMenu.Components.Player.Other
{
    public class LocalPlayerSpeedyRun
    {
        public static void EnableSpeedyRun() => DebugConsole.Instance._speedyrun(Settings.SpeedyRun ? "on" : "off");
    }
}