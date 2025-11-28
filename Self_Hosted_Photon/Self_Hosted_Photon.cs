using BepInEx;
using BepInEx.Logging;
using REPOLib;
using UnityEngine;

namespace Self_Hosted_Photon;

/// <summary>
/// Self_Hosted_Photon's main plugin class.
/// </summary>
[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
[BepInDependency(REPOLib.MyPluginInfo.PLUGIN_GUID, BepInDependency.DependencyFlags.HardDependency)]
public class Plugin : BaseUnityPlugin
{
    internal static Plugin Instance { get; private set; } = null!;

    internal static string PluginFolder => System.IO.Path.GetDirectoryName(Instance.Info.Location)!;

    private void Awake()
    {
        Instance = this;

        Self_Hosted_Photon.Logger.Initialize(
            BepInEx.Logging.Logger.CreateLogSource(MyPluginInfo.PLUGIN_GUID)
        );

        Self_Hosted_Photon.Logger.LogDebug($"{MyPluginInfo.PLUGIN_NAME} has awoken!");

        ConfigManager.Initialize(Config);
        Self_Hosted_Photon.Logger.LogDebug("ConfigManager initialized.");

        Self_Hosted_Photon.Logger.LogInfo(
            $"{Info.Metadata.GUID} v{Info.Metadata.Version} has loaded!"
        );
    }
}
