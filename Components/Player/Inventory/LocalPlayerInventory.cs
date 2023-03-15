using Construction;
using Il2CppSystem.Collections.Generic;
using Il2CppSystem.IO;
using Sons.Input;
using Sons.Items.Core;
using UnityEngine;
using TheForest.Utils;
using TheForest.Items.Inventory;
using UnityEngine.SceneManagement;
using Types = UnityEngine.Types;

namespace SOTFModMenu.Components.Player.Inventory
{
    internal class LocalPlayerInventory
    {
        public static void AddItemToInventory(int itemID, int amount = 1)
        {
            try
            {
                LocalPlayer.Inventory.AddItem(itemID, amount);
            }
            catch
            {
                Plugin.Plugin.log.LogError($"Failed to add item to inventory! RefID: {itemID}, RefAmount: {amount}");
            }
        }
    }
}
