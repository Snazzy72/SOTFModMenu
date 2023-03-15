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

namespace SOTFModMenu
{
    public class Main
    {
        public class GameInstanceMonoBehaviour : MonoBehaviour
        {
            public static Scene sonsMainScene;
            public static Camera cameraMain;
            private void Update()
            {
                if (!sonsMainScene.isLoaded)
                {
                    sonsMainScene = SceneManager.GetSceneByName("SonsMain");
                }

                if (cameraMain == null)
                {
                    cameraMain = Camera.main ?? null;
                }

                if (!LocalPlayer.IsInWorld)
                {
                    return;
                }

                AddItem(431, 1); //Firefighter axe => Change the itemID to any existing ID to add that item.
            }

            public static void AddItem(int itemID, int amount)
            {
                try
                {
                    LocalPlayer.Inventory.AddItem(itemID, amount);
                    Plugin.Plugin.log.LogInfo($"Successfully added item with id: {itemID} and amount: {amount}x");
                }
                catch
                {
                    Plugin.Plugin.log.LogError($"Failed to add item with id: {itemID} and amount: {amount}x");
                }
            }
        }
    }
}
