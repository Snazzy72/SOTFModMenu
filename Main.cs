using UnityEngine;
using UnityEngine.SceneManagement;
using TheForest.Utils;
using Sons.Multiplayer.Gui;
using static SOTFModMenu.Plugin.Plugin;
using SOTFModMenu.Components.Cache;
using SOTFModMenu.Components.Overlay;
using SOTFModMenu.Components.Utility;
using SOTFModMenu.Components.Player.Stats;
using SOTFModMenu.Components.Player.Ammo;
using SOTFModMenu.Components.Player.Crafting;
using SOTFModMenu.Components.Player.Inventory;
using SOTFModMenu.Components.Player.Other;

namespace SOTFModMenu 
{
    public class Main
    {
        public class GameInstanceMonoBehaviour : MonoBehaviour
        {
            public static Scene sonsMainScene;
            public static Camera cameraMain;

            PlayerListBase playerListBase = new();

            private void OnGUI()
            {
                if (!Settings.Visible)
                {
                    return;
                }

                OverlayMenu.Display();
            }

            private void Update()
            {  

                CacheManager.CacheMainScene(sonsMainScene);
                CacheManager.CacheMainCamera(cameraMain);

                if (!LocalPlayer.IsInWorld)
                {
                    return;
                }

                OverlayMenu.ShowMenu(playerListBase);

                LocalPlayerInventory.ItemSpawnerHotkeyPressed();
                LocalPlayerAmmo.EnableInfAmmo();
                LocalPlayerSpeedyRun.EnableSpeedyRun();
                LocalPlayerStats.ModifyVitals();
                LocalPlayerCraftingSystem.EnableInstantBuild();
                LocalPlayerCraftingSystem.EnableInfBuild();
                LocalPlayerCraftingSystem.EnableInfLogs();
            }
        }
    }
}
