using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLoadingScene : MonoBehaviour
{
    private int L;
    void Start()
    {
        if (PlayerPrefs.GetInt("AAAAAAAAAAAAAA") == 0)
        {   
            foreach (var res in Screen.resolutions)
            {
                L = res.width;
            }
            PlayerPrefs.SetInt("Joystick", 1);
            PlayerPrefs.SetFloat("PlayerHP", 10f);
            PlayerPrefs.SetFloat("ScaleJoystick", 2);

            PlayerPrefs.SetFloat("FixJoystickXM", 300);
            PlayerPrefs.SetFloat("FixJoystickYM", 300);
            PlayerPrefs.SetFloat("FixJoystickXF", L-300);
            PlayerPrefs.SetFloat("FixJoystickYF", 300);

            PlayerPrefs.SetFloat("OthJoystickXM", 0);
            PlayerPrefs.SetFloat("OthJoystickYM", 0);
            PlayerPrefs.SetFloat("OthJoystickXF", 0);
            PlayerPrefs.SetFloat("OthJoystickYF", 0);

            PlayerPrefs.SetFloat("ReloadX", -700);
            PlayerPrefs.SetFloat("ReloadY", 0);


            PlayerPrefs.SetFloat("MusicVolum", 1);
            PlayerPrefs.SetFloat("SoundsVolume", 1);

            PlayerPrefs.SetInt("AAAAAAAAAAAAAA", 1);
        }
    }
}
