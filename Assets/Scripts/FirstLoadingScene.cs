using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLoadingScene : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetInt("AAAAAAAAAAAAAA") == 0)
        {
            PlayerPrefs.SetInt("Joystick", 1);
            PlayerPrefs.SetFloat("PlayerHP", 10f);
            PlayerPrefs.SetFloat("ScaleJoystick", 1);

            PlayerPrefs.SetFloat("FixJoystickXM", 100);
            PlayerPrefs.SetFloat("FixJoystickYM", 100);
            PlayerPrefs.SetFloat("FixJoystickXF", -100);
            PlayerPrefs.SetFloat("FixJoystickYF", 100);

            PlayerPrefs.SetFloat("OthJoystickXM", 0);
            PlayerPrefs.SetFloat("OthJoystickYM", 0);
            PlayerPrefs.SetFloat("OthJoystickXF", 0);
            PlayerPrefs.SetFloat("OthJoystickYF", 0);

            PlayerPrefs.SetFloat("MusicVolum", 1);
            PlayerPrefs.SetFloat("SoundsVolume", 1);

            PlayerPrefs.SetInt("AAAAAAAAAAAAAA", 1);
        }
    }
}
