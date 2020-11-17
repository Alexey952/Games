﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicControler : MonoBehaviour
{

    public  AudioSource audioSrc;
    private GameObject  MainCamera;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Main");
    }
    void Update()
    {
        MainCamera = GameObject.FindWithTag("MainCamera");
        gameObject.transform.position = MainCamera.transform.position;
        audioSrc.volume = PlayerPrefs.GetFloat("MusicVolum");
    }
}
