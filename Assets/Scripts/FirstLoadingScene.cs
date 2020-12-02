using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLoadingScene : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetFloat("PlayerHP", 10f);
    }
}
