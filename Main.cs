using UnityEngine;
using TheForest.Utils;
using UnityEngine.SceneManagement;
using SOTFModMenu.Components.Cache;
using SOTFModMenu.Components.Overlay;
using SOTFModMenu.Components.Utility;
using SOTFModMenu.Components.Player.Stats;
using SOTFModMenu.Components.Player.Ammo;
using SOTFModMenu.Components.Player.Crafting;
using SOTFModMenu.Components.Player.Other;

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

                OverlayMenu.Display();
            }

            private void Update()
            {
                OverlayMenu.ShowMenu();

                CacheManager.CacheMainScene(sonsMainScene);
                CacheManager.CacheMainCamera(cameraMain);

                if (!LocalPlayer.IsInWorld)
                {
                    return;
                }

                LocalPlayerAmmo.EnableInfAmmo();
                LocalPlayerSpeedyRun.EnableSpeedyRun();
                LocalPlayerStats.ModifyVitals();
                LocalPlayerCraftingSystem.EnableInstantBuild();
                LocalPlayerCraftingSystem.EnableInfBuild();
            }
        }
    }
}
