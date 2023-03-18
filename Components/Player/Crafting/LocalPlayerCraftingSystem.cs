using SOTFModMenu.Components.Utility;
using TheForest.Utils;

namespace SOTFModMenu.Components.Player.Crafting
{
    public class LocalPlayerCraftingSystem
    {
        public static void EnableInstantBuild()
        {
            LocalPlayer.StructureCraftingSystem.InstantBuild = Settings.InstantBuild;
        }

        public static void EnableInfBuild()
        {
            LocalPlayer.Inventory.HeldOnlyItemController.InfiniteHack = Settings.InfBuild;
        }

        public static void EnableInfLogs()
        {
            if (!Settings.InfLogs)
            {
                return;
            }

            if (LocalPlayer.Inventory.Logs.HasLogs && LocalPlayer.Inventory.Logs.Amount < 2)
            {
                LocalPlayer.Inventory.Logs._heldItemController._heldCount = 2;
            }
        }
    }
}