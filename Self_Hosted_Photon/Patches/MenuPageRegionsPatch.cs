using System.Collections;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Self_Hosted_Photon.Patches;

[HarmonyPatch(typeof(MenuPageRegions))]
internal static class MenuPageRegionsPatch
{
    [HarmonyPatch(nameof(MenuPageRegions.Start))]
    [HarmonyPrefix]
    private static bool StartPrefix(MenuPageRegions __instance)
    {
        if (!ConfigManager.Enabled.Value)
            return true;

        __instance.StartCoroutine(GetRegions(__instance));

        return false;
    }

    private static IEnumerator GetRegions(MenuPageRegions __instance)
    {
        PhotonNetwork.Disconnect();
        while (
            PhotonNetwork.NetworkingClient.State != ClientState.Disconnected
            && PhotonNetwork.NetworkingClient.State != 0
        )
        {
            yield return null;
        }
        DataDirector.instance.PhotonSetAppId();
        SteamManager.instance.SendSteamAuthTicket();
        PhotonNetwork.PhotonServerSettings.AppSettings.FixedRegion = "";
        ServerSettings.ResetBestRegionCodeInPreferences();
        PhotonNetwork.ConnectUsingSettings();
        while (!__instance.connectedToMaster)
        {
            yield return null;
        }
        __instance.loadingGraphics.SetDone();
        yield return new WaitForSecondsRealtime(0.3f);
        Vector3 _position = __instance.transformStartPosition.position;
        MenuElementRegion component = Object
            .Instantiate(
                __instance.regionPrefab,
                _position,
                Quaternion.identity,
                __instance.transformStartPosition.parent
            )
            .GetComponent<MenuElementRegion>();
        component.textName.text = "Custom Host";
        component.textName.color = Color.white;
        component.textPing.text = "";
        component.parentPage = __instance;
        component.regionCode = "custom";

        PhotonNetwork.Disconnect();
        __instance.menuScrollBox.enabled = true;
        while (__instance.scrollCanvasGroup.alpha < 0.99f)
        {
            __instance.scrollCanvasGroup.alpha += Time.deltaTime * 5f;
            yield return null;
        }
        __instance.scrollCanvasGroup.alpha = 1f;
    }
}
