using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaNapadenia : MonoBehaviour
{
    private float HP;

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Monster")
        {
            HP = PlayerPrefs.GetFloat("PlayerHPnow") - 1;
            PlayerPrefs.SetFloat("PlayerHPnow", HP);
        }
    }
}
