using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingStart : MonoBehaviour
{
    public GameObject Settings;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Settings.SetActive(true);
        }
    }
}
