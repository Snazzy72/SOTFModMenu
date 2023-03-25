using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using Il2CppInterop.Runtime.Injection;
using System.Reflection;
using UnityEngine;
using BepInEx.Logging;
using System.IO;
using Object = UnityEngine.Object;
using static SOTFModMenu.Plugin.PluginData.About;


namespace SOTFModMenu.Plugin
{
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    public class Plugin : BepInEx.Unity.IL2CPP.BasePlugin
    {
        public static ConfigFile ConfigFile = new(Path.Combine(Paths.ConfigPath, "SOTFModMenu.cfg"), true);
        public static ConfigEntry<KeyCode> OverlayMenuKeybind = ConfigFile.Bind("Hotkeys", "Toggle", KeyCode.BackQuote, "View and Hide the Overlay Menu");
        public static ConfigEntry<KeyCode> ItemSpawnerKeybind = ConfigFile.Bind("Hotkeys", "SpawnItem", KeyCode.F10, "Spawn currently stored ItemID");

        public Plugin()
        {
            log = Log;
        }

        public override void Load()
        {
            try
            {
                RegisterIL2CPPType();
                Log.LogMessage("Successfully Registered IL2CPP Type: 'GameInstanceMonoBehavior'!");
            }
            catch
            {
                Log.LogError($"Failed to Register IL2CPP type: 'GameInstanceMonoBehaviour'!");
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
            Log.LogMessage($"ModMenu overlay keybind set to: {OverlayMenuKeybind.Value}");
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