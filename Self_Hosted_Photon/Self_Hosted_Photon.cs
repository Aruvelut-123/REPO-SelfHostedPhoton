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
    internal static new ManualLogSource Logger => Instance._logger;

    internal static string PluginFolder => System.IO.Path.GetDirectoryName(Instance.Info.Location)!;

    private ManualLogSource _logger => base.Logger;

    private void Awake()
    {
        Instance = this;

        // Prevent the plugin from being deleted
        this.gameObject.transform.parent = null;
        this.gameObject.hideFlags = HideFlags.HideAndDontSave;

        Logger.LogInfo($"{Info.Metadata.GUID} v{Info.Metadata.Version} has loaded!");
    }
}
