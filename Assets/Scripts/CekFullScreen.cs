using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CekFullScreen : MonoBehaviour
{
    private void Awake()
    {
        Toggle toggle = this.gameObject.GetComponent<Toggle>();
        if (BacksoundFullscreen.FullscreenStatus)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }

        if (toggle.isOn)
        {
            Screen.fullScreen = true;
            BacksoundFullscreen.FullscreenStatus = true;
        }
        else
        {
            Screen.fullScreen = false;
            BacksoundFullscreen.FullscreenStatus = false;
        }
    }

    public void FullScreenOnOf()
    {
        if (Screen.fullScreen)
        {
            Screen.fullScreen = false;
            BacksoundFullscreen.FullscreenStatus = true;
        }
        else
        {
            Screen.fullScreen = true;
            BacksoundFullscreen.FullscreenStatus = false;
        }
    }
}