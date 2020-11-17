using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideCamera : MonoBehaviour
{
    public  Joystick joy;
    private float    Horizontal;
    void FixedUpdate()
    {
        Horizontal = joy.Horizontal;
        PlayerPrefs.SetFloat("SliderCamera", Horizontal);
    }
}
