using ExitGames.Client.Photon;
using HarmonyLib;
using Photon.Pun;

namespace Self_Hosted_Photon.Patches;

[HarmonyPatch(typeof(DataDirector))]
internal static class DataDirectorPatch
{
    [HarmonyPatch(nameof(DataDirector.PhotonSetAppId))]
    [HarmonyPrefix]
    private static bool PhotonSetAppIdPrefix()
    {
        if (!ConfigManager.Enabled.Value)
            return true;

        PhotonNetwork.NetworkingClient.SerializationProtocol = SerializationProtocol.GpBinaryV16;

        PhotonNetwork.PhotonServerSettings.AppSettings.AppIdRealtime = string.Empty;
        PhotonNetwork.PhotonServerSettings.AppSettings.AppIdVoice = string.Empty;

        var serverAddress = ConfigManager.ServerAddress.Value;
        var serverPort = ushort.Parse(ConfigManager.ServerPort.Value);
        PhotonNetwork.PhotonServerSettings.AppSettings.Server = serverAddress;
        PhotonNetwork.PhotonServerSettings.AppSettings.Port = serverPort;

        PhotonNetwork.PhotonServerSettings.AppSettings.UseNameServer = false;

        return false;
    }
}
