using UnityEngine;
using TheForest.Utils;
using UnityEngine.SceneManagement;
using SOTFModMenu.Components.Cache;
using SOTFModMenu.Components.Player.Inventory;

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
                CacheManager.CacheMainScene(sonsMainScene);
                CacheManager.CacheMainCamera(cameraMain);

                if (!LocalPlayer.IsInWorld)
                {
                    return;
                }

                LocalPlayerInventory.AddItemToInventory(358); //=> Shotgun - Change to any other valid itemID to add to inventory
            }
        }
    }
}
