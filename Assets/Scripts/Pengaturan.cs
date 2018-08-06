using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pengaturan : MonoBehaviour
{
    public string SourceBacksound;

    public static bool FullScreenStatus = true;
    public static bool BackSoundStatus = true;

    // Use this for initialization
    private void Start()
    {
        AudioSource backsound = GameObject.Find(SourceBacksound).GetComponent<AudioSource>();
        if (BackSoundStatus == true)
        {
            backsound.mute = false;
        }
        else
        {
            backsound.mute = true;
        }

        if (FullScreenStatus == true)
        {
            Screen.fullScreen = true;
        }
        else
        {
            Screen.fullScreen = false;
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}