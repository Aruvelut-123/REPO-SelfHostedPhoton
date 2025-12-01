using HarmonyLib;
using Steamworks.Data;

namespace Self_Hosted_Photon.Patches;

[HarmonyPatch(typeof(Lobby))]
internal static class LobbyPatch
{
    [HarmonyPatch(nameof(Lobby.SetData))]
    [HarmonyPrefix]
    private static void SetDataPrefix(string key, ref string value)
    {
        if (!ConfigManager.Enabled.Value)
            return;

        // TODO: dig deeper into the original problem where value would be null or empty
        if (key == "Region" && string.IsNullOrWhiteSpace(value))
        {
            value = "eu";
            Logger.LogDebug($"Overriding Region to eu in {nameof(Lobby.SetData)}");
        }
    }
}
