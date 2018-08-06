using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CekSound : MonoBehaviour
{
    public string SourceBackSound;

    private void Awake()
    {
        Toggle toggle = this.gameObject.GetComponent<Toggle>();
        if (BacksoundFullscreen.BacksoundStatus == true)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }

        AudioSource backsound = GameObject.Find(SourceBackSound).GetComponent<AudioSource>();
        if (toggle.isOn)
        {
            backsound.mute = false;
            BacksoundFullscreen.BacksoundStatus = true;
        }
        else
        {
            backsound.mute = true;
            BacksoundFullscreen.BacksoundStatus = false;
        }
    }

    public void BackSoundOnOf()
    {
        AudioSource backSound = GameObject.Find(SourceBackSound).GetComponent<AudioSource>();

        if (backSound.mute)
        {
            backSound.mute = false;
            BacksoundFullscreen.BacksoundStatus = true;
        }
        else
        {
            backSound.mute = true;
            BacksoundFullscreen.BacksoundStatus = false;
        }
    }

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }
}