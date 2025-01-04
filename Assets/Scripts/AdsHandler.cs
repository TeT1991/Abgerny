using GamePush;
using System;
using UnityEngine;


public class AdsHandler : MonoBehaviour
{
    public Action OnFullScreenClose;

    public void ShowRewarded()
    {
        string idOrTag = "";
        GP_Ads.ShowRewarded(idOrTag);
    }

    public void ShowFullscreen()
    {
        GP_Ads.ShowFullscreen(FullscreenStart, FullscreenClose);
        FullscreenStart(); //”брать при компил€ции билда
        FullscreenClose(true);//”брать при компил€ции билда
    }

    private void FullscreenStart() => Debug.Log("ON FULLSCREEN START");

    private void FullscreenClose(bool success)
    {
        Debug.Log("ON FULLSCREEN CLOSE");
        OnFullScreenClose?.Invoke();
    }
}
