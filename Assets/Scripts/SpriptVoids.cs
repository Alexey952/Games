using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpriptVoids : MonoBehaviour
{
    private int             h;
    public  Sprite          spr1,spr3;                    //спрайты оружия
    private Image           WeaponImage;                  //кнопка смены оружия
    private GameObject      ContinueButton;               //кнопка прожолжнния игру по нажатия паузы
    private GameObject      VolumSlider;
    private GameObject      SoundsSlider;
    private GameObject      VolumText;
    private string          WhatScene;
    void Start()
    {
        WhatScene = SceneManager.GetActiveScene().name;
        if (WhatScene != "JoystickSettings")
        {
            WeaponImage = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Image>();
            VolumText = GameObject.FindGameObjectWithTag("TextVol");
            VolumText.SetActive(false);
            ContinueButton = GameObject.FindGameObjectWithTag("Continue");
            ContinueButton.SetActive(false);
            VolumSlider = GameObject.FindGameObjectWithTag("VolSlid");
            SoundsSlider = GameObject.FindGameObjectWithTag("SoundSlid");
            VolumSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MusicVolum");
            SoundsSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("SoundsVolume");
            VolumSlider.SetActive(false);
            SoundsSlider.SetActive(false);
        }
        PlayerPrefs.SetInt("PositionJoystick", 0);
    }
    public void CloseAny(GameObject obj)
    {
        obj.SetActive(false);
    }
    public void Starting()
    {
        h = UnityEngine.Random.Range(3, 5);
        PlayerPrefs.SetInt("SceneLoading", h);
        SceneManager.LoadScene(1);
    }
    public void ChangedJoystick()
    {
        SceneManager.LoadScene("JoystickSettings");
    }
    public void JoystickExit()
    {
        SceneManager.LoadScene(2);
    }
    public void JoystickTransformPosition()
    {
        if (PlayerPrefs.GetInt("PositionJoystick") == 0)
        {
            PlayerPrefs.SetInt("PositionJoystick", 1);
        }
        else
        {
            PlayerPrefs.SetInt("PositionJoystick", 0);
        }
    }



    public void WeaponImages()          //функция смены оружия
    {
        if (WeaponImage.sprite == spr1)
        {
            WeaponImage.sprite = spr3;
        }
        else
        {
            WeaponImage.sprite = spr1;
        }
    }
    public void Pause()                         //пауза
    {
        Time.timeScale = 0;
        ContinueButton.SetActive(true);
        VolumSlider.SetActive(true);
        VolumText.SetActive(true);
        SoundsSlider.SetActive(true);
    }
    public void Continue()                  //продолжение
    {
        Time.timeScale = 1;
        ContinueButton.SetActive(false);
        VolumSlider.SetActive(false);
        VolumText.SetActive(false);
        SoundsSlider.SetActive(false);
    }
    public void SetVolum()
    {
        PlayerPrefs.SetFloat("MusicVolum", VolumSlider.GetComponent<Slider>().value);
    }
    public void SetVolumeZ()
    {
        PlayerPrefs.SetFloat("SoundsVolume", SoundsSlider.GetComponent<Slider>().value);
    }
}
