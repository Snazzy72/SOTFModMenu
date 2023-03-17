using UnityEngine;
using TheForest.Utils;
using UnityEngine.SceneManagement;
using SOTFModMenu.Components.Cache;
using SOTFModMenu.Components.Player.Inventory;
using SOTFModMenu.Components.Overlay;
using UnityEngine.Rendering.HighDefinition;
using System;
using SOTFModMenu.Components.Utility;
using Il2CppSystem.Collections.Generic;
using Sons.Input;
using TheForest.Items.Inventory;

namespace SOTFModMenu
{
    public class Main
    {
        public class GameInstanceMonoBehaviour : MonoBehaviour
        {
            public static Scene sonsMainScene;
            public static Camera cameraMain;

            private void OnGUI()
            {
                if (!Settings.Visible)
                {
                    return;
                }
               
                GUI.color = Color.white;

                OverlayUIHelper.Section("Player", 10, 10, 165, 241, 2, 20, 2);
                Settings.Health = OverlayUIHelper.Button("Max Health: ", Settings.Health);
                Settings.Stamina = OverlayUIHelper.Button("Max Stamina: ", Settings.Stamina);
                Settings.Strength = OverlayUIHelper.Button("Max Strength: ", Settings.Strength);
                Settings.LungCapacity = OverlayUIHelper.Button("Max LungCapacity: ", Settings.LungCapacity);
                Settings.Cold = OverlayUIHelper.Button("No Cold: ", Settings.Cold);
                Settings.Hunger = OverlayUIHelper.Button("No Hunger: ", Settings.Hunger);
                Settings.Thirst = OverlayUIHelper.Button("No Thirst: ", Settings.Thirst);
                Settings.Rested = OverlayUIHelper.Button("Always Rested: ", Settings.Rested);
                Settings.InfAmmo = OverlayUIHelper.Button("Infinite Ammo: ", Settings.InfAmmo);
                Settings.SpeedyRun = OverlayUIHelper.Button("SpeedRun: ", Settings.SpeedyRun);

                OverlayUIHelper.Section("Item Spawner", 10, 256, 165, 80, 2, 15, 2);
                OverlayUIHelper.Label("Enter id & amount");
                Settings.TextFieldItemID = GUI.TextField(new Rect(14, 292, 75, 20), Settings.TextFieldItemID);
                Settings.TextFieldAmount = GUI.TextField(new Rect(90, 292, 80, 20), Settings.TextFieldAmount);
                GUI.skin.GetStyle("TextField").alignment = TextAnchor.MiddleCenter;  
                if (GUI.Button(new Rect(12, 314, 161, 20), "Spawn item"))
                    LocalPlayerInventory.AddItemToInventory();

                GUI.backgroundColor = Color.grey;
            }

            private void Update()
            {
                ShowMenu();

                CacheManager.CacheMainScene(sonsMainScene);
                CacheManager.CacheMainCamera(cameraMain);

                if (!LocalPlayer.IsInWorld)
                {
                    return;
                }
            }

            private void ShowMenu()
            {
                if (Input.GetKeyDown(KeyCode.BackQuote))
                {
                    Settings.Visible = !Settings.Visible;
                    if (Settings.Visible)
                    {
                        InputSystem.SetState(0, true);
                        Cursor.visible = true;
                        Cursor.lockState = CursorLockMode.None;
                        return;
                    }
                    if (LocalPlayer.IsInWorld || LocalPlayer.IsInInventory || LocalPlayer.IsConstructing || LocalPlayer.IsInMidAction || LocalPlayer.CurrentView == PlayerInventory.PlayerViews.Hidden)
                    {
                        InputSystem.SetState(0, false);
                        Cursor.visible = false;
                        Cursor.lockState = CursorLockMode.Locked;
                    }
                }
            }
        }
    }
}
