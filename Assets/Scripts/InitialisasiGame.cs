using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialisasiGame : MonoBehaviour
{
    public static AudioSource UtamaSound;
    public static GameObject UtamaPanel;
    public static GameObject PetunjukPanel;
    public static GameObject PengaturanPanel;
    public static GameObject TentangPanel;
    public static GameObject KeluarPanel;

    public AudioSource utamaSound;
    public GameObject utamaPanel;
    public GameObject petunjukPanel;
    public GameObject pengaturanPanel;
    public GameObject tentangPanel;
    public GameObject keluarPanel;

    // Use this for initialization
    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        UtamaSound = utamaSound;
        UtamaPanel = UtamaPanel;
        PetunjukPanel = petunjukPanel;
        PengaturanPanel = pengaturanPanel;
        TentangPanel = tentangPanel;
        KeluarPanel = keluarPanel;
    }

    // Update is called once per frame
    private void Update()
    {
    }
}