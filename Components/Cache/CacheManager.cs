using UnityEngine;
using UnityEngine.SceneManagement;

namespace SOTFModMenu.Components.Cache
{
    internal static class CacheManager
    {
        public static void CacheMainCamera(Camera cameraMain)
        {
            if (cameraMain == null)
            {
                cameraMain = Camera.main ?? null;
            }
        }

        public static void CacheMainScene(Scene sonsMainScene)
        {
            if (!sonsMainScene.isLoaded)
            {
                sonsMainScene = SceneManager.GetSceneByName("SonsMain");
            }
        }
    }
}