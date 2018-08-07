﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AturanNPC : MonoBehaviour
{
    // Use this for initialization
    private Transform dicari;

    public string tagPlayer = "Player";
    public float lembamRotasi = 1f;
    private Animation anim;
    private float jarakPlayer = 0f;
    public float jarakJalan = 70f;
    public float jarakSerang = 3f;

    private void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (GameObject.FindGameObjectWithTag(tagPlayer))
        {
            dicari = GameObject.FindGameObjectWithTag(tagPlayer).GetComponent<Transform>();
            jarakPlayer = Vector3.Distance(dicari.position, transform.position);
        }
        else
        {
            Debug.Log("player tidak ditemukan");
            jarakPlayer = 0f;
        }

        if (GameObject.FindGameObjectWithTag(tagPlayer))
        {
            if (jarakPlayer < jarakJalan)
            {
                arahPlayer();
                jalan();
            }

            if (jarakPlayer <= jarakSerang)
            {
                serang();
            }
        }
        else
        {
            Debug.Log("Player tidak ketemu");
        }
    }

    private void arahPlayer()
    {
        Quaternion rotasi = Quaternion.LookRotation(dicari.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotasi, Time.deltaTime * lembamRotasi);
    }

    private void jalan()
    {
        anim.GetComponent<Animation>().wrapMode = WrapMode.Loop;
        anim.GetComponent<Animation>().CrossFade("Walk");
    }

    private void serang()
    {
        anim.GetComponent<Animation>().wrapMode = WrapMode.Loop;
        anim.GetComponent<Animation>().CrossFade("Attack");
    }
}