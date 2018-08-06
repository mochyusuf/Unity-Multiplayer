using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackSoundTerus : MonoBehaviour
{
    public static BackSoundTerus objek = null;

    private void Awake()
    {
        if (objek == null)
        {
            objek = this;
        }
        else if (objek != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
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