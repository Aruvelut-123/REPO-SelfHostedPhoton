using BepInEx;
using HarmonyLib;

namespace Self_Hosted_Photon;

/// <summary>
/// Self_Hosted_Photon's main plugin class.
/// </summary>
[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static Plugin Instance { get; private set; } = null!;

    internal static string PluginFolder => System.IO.Path.GetDirectoryName(Instance.Info.Location)!;
    internal Harmony? Harmony { get; set; }

    private void Awake()
    {
        Instance = this;

        Self_Hosted_Photon.Logger.Initialize(
            BepInEx.Logging.Logger.CreateLogSource(MyPluginInfo.PLUGIN_GUID)
        );

        Self_Hosted_Photon.Logger.LogDebug($"{MyPluginInfo.PLUGIN_NAME} has awoken!");

        ConfigManager.Initialize(Config);
        Self_Hosted_Photon.Logger.LogDebug("ConfigManager initialized.");

        HarmonyPatch();
        Self_Hosted_Photon.Logger.LogDebug("Harmony patches applied.");

        Self_Hosted_Photon.Logger.LogInfo(
            $"{Info.Metadata.GUID} v{Info.Metadata.Version} has loaded!"
        );
    }

    internal void HarmonyPatch()
    {
        Harmony ??= new Harmony(Info.Metadata.GUID);
        Harmony.PatchAll();
    }

    internal void HarmonyUnpatch()
    {
        Harmony?.UnpatchSelf();
    }
}
