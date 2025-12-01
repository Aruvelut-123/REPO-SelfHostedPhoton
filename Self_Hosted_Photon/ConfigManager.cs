using BepInEx.Configuration;

namespace Self_Hosted_Photon;

internal static class ConfigManager
{
    public static ConfigFile ConfigFile { get; private set; } = null!;

    public static ConfigEntry<bool> Enabled { get; private set; } = null!;

    public static ConfigEntry<string> ServerAddress { get; private set; } = null!;
    public static ConfigEntry<string> ServerPort { get; private set; } = null!;

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

        ServerAddress = ConfigFile.Bind(
            "Server",
            "Address",
            defaultValue: "localhost",
            "The IP address or hostname of the Photon server."
        );

        ServerPort = ConfigFile.Bind(
            "Server",
            "Port",
            defaultValue: "5055",
            "The port number of the Photon server."
        );
    }
}
