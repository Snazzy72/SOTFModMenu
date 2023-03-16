using TheForest.Utils;
using static SOTFModMenu.Components.Validation.ValidateItemID;
using static SOTFModMenu.Plugin.Plugin;

namespace SOTFModMenu.Components.Player.Inventory
{
    internal static class LocalPlayerInventory
    {
        public static void AddItemToInventory(int itemID, int amount = 1)
        {
            if (IsValidItemId(itemID))
            {
                try
                {
                    LocalPlayer.Inventory.AddItem(itemID, amount);
                }
                catch
                {
                    log.LogError($"Unable to add item with ID: {itemID}");
                }
            }
            else
            {
                log.LogError($"Invalid item ID given: {itemID}");
            }
        }
    }
}
