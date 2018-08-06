using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PindahScene : MonoBehaviour
{
    public AudioSource ButtonSound;
    public string namaScene;

    public void PindahKeScene()
    {
        AudioSource buttonSound = ButtonSound.GetComponent<AudioSource>();
        buttonSound.PlayOneShot(buttonSound.clip);

        Scene scene = SceneManager.GetActiveScene();
        if (scene.name != namaScene)
        {
            SceneManager.LoadScene(namaScene);
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