using BepInEx;
using BepInEx.NET.Common;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using Il2CppInterop.Runtime.Injection;
using System.IO;
using System.Reflection;
using UnityEngine;
using BepInEx.Logging;
using Object = UnityEngine.Object;
using static SOTFModMenu.Plugin.PluginData.About;
using Il2CppSystem;

namespace SOTFModMenu.Plugin
{
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    public class Plugin : BepInEx.Unity.IL2CPP.BasePlugin
    {
        public Plugin()
        {
            log = Log;
        }

        public override void Load()
        {
            try
            {
                RegisterIL2CPPType();
                Log.LogMessage("Successfully Registered IL2CPP Type: 'GameInstanceMonoBehavior'!'");
            }
            catch
            {
                Log.LogError($"Failed to Regiset IL2CPP type: 'GameInstanceMonoBehaviour'!");
            }

            try
            {
                Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), null);
                Log.LogMessage("Successfully Registered Patches!");
            }
            catch
            {
                Log.LogError("Failed to register Patches!");
            }
            Log.LogMessage($"Plugin '{PLUGIN_GUID}' is loaded!");
        }

        private static void RegisterIL2CPPType()
        {
            ClassInjector.RegisterTypeInIl2Cpp<Main.GameInstanceMonoBehaviour>();
            GameObject hookedGameObject = new("HookedGameObject");
            hookedGameObject.AddComponent<Main.GameInstanceMonoBehaviour>();
            hookedGameObject.hideFlags = HideFlags.HideAndDontSave;
            Object.DontDestroyOnLoad(hookedGameObject);
        }

        public static ManualLogSource log;
    }
}