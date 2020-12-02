using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{

    public  Image      image;
    private float      HP;

    void Update()
    {
        HP = PlayerPrefs.GetFloat("PlayerHPnow")/PlayerPrefs.GetFloat("PlayerHP");
        image.fillAmount = HP;
    }
}
