using System;
using TheForest.Utils;
using SOTFModMenu.Components.Utility;
using static SOTFModMenu.Plugin.Plugin;
using static SOTFModMenu.Components.Validation.ValidateItemID;


namespace SOTFModMenu.Components.Player.Inventory
{
    public static class LocalPlayerInventory
    {
        public static void AddItemToInventory()
        {
            try
            {
                int itemID = int.Parse(Settings.TextFieldItemID);
                int amount = int.Parse(Settings.TextFieldAmount);
                if (!IsValidItemId(itemID))
                {
                    log.LogError($"Invalid itemID given: {itemID}");
                    return;
                }

                LocalPlayer.Inventory.AddItem(itemID, amount);
            }
            catch (Exception error)
            {
                log.LogFatal($"Exception occured: {error}");
            }
        }
    }
}
