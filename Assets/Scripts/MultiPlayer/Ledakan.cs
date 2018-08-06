using UnityEngine;
using System.Collections;

public class Ledakan : Photon.PunBehaviour
{
    public string tagMusuh = "Musuh";
    public int satuanSkor = 300;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (photonView.isMine)
        {
            if (other.gameObject.CompareTag(tagMusuh))
            {
                PhotonNetwork.player.AddScore(satuanSkor);
            }
        }
    }
}