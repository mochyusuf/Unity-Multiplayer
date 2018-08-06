using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PindahPanel : MonoBehaviour
{
    public AudioSource buttonSound;
    public GameObject PanelAwal;
    public GameObject PanelTujuan;

    public void GantiKePanelBaru()
    {
        buttonSound.PlayOneShot(buttonSound.clip);
        PanelAwal.SetActive(false);
        PanelTujuan.SetActive(true);
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