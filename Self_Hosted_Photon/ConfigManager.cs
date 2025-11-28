using BepInEx.Configuration;

namespace Self_Hosted_Photon;

internal static class ConfigManager
{
    public static ConfigFile ConfigFile { get; private set; } = null!;

    public static ConfigEntry<bool> Enabled { get; private set; } = null!;

    public static void Initialize(ConfigFile configFile)
    {
        ConfigFile = configFile;
        BindConfigs();
    }

    private static void BindConfigs()
    {
        Enabled = ConfigFile.Bind(
            "General",
            "Enabled",
            defaultValue: true,
            "Enable or disable the plugin."
        );
    }
}
