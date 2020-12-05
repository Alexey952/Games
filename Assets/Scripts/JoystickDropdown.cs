using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class JoystickDropdown : MonoBehaviour
{
    public  TMPro.TMP_Dropdown dropdown;
    private GameObject         canvas;
    private GameObject         Obj;
    private GameObject         Obj1;
    public  GameObject         Dinamic;
    public  GameObject         Fixed;
    public  GameObject         Floating;
    public  GameObject         Variable;
    private Joystick           Joy;    
    private float              L = 2960f;     
    

    void Start()
    {
        foreach (var res in Screen.resolutions)
        {
            L = res.width;
        }
        Joy = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();
        canvas = GameObject.FindGameObjectWithTag("canvas");
        dropdown.value = PlayerPrefs.GetInt("Joystick");
        Joystick();
    }
    public void Joystick()
    {
        Obj = GameObject.FindGameObjectWithTag("MoveJoystick");
        Destroy(Obj);
        Obj1 = GameObject.FindGameObjectWithTag("FireJoystick");
        Destroy(Obj1);
        PlayerPrefs.SetInt("Joystick", dropdown.value);
        if (dropdown.value == 0)
        {
            Obj = Instantiate(Dinamic, new Vector3(PlayerPrefs.GetFloat("OthJoystickXM"), PlayerPrefs.GetFloat("OthJoystickYM"),0), Quaternion.identity, canvas.transform);
            Obj.GetComponent<RectTransform>().anchorMax = new Vector2(0f,0f);
            Obj.GetComponent<RectTransform>().anchorMin = new Vector2(0f,0f);
            Obj.GetComponent<RectTransform>().pivot = new Vector2(0f,0f);
            Obj.tag = "MoveJoystick";
            Obj1 = Instantiate(Dinamic, new Vector3(-L+PlayerPrefs.GetFloat("OthJoystickXF"), PlayerPrefs.GetFloat("OthJoystickYF"),0), Quaternion.identity, canvas.transform);
            Obj1.GetComponent<RectTransform>().anchorMax = new Vector2(1f,0f);
            Obj1.GetComponent<RectTransform>().anchorMin = new Vector2(1f,0f);
            Obj1.GetComponent<RectTransform>().pivot = new Vector2(1f,0f);
            Obj1.tag = "FireJoystick";
        }
        else if (dropdown.value == 1)
        {
            Obj = Instantiate(Fixed, new Vector3(PlayerPrefs.GetFloat("FixJoystickXM"), PlayerPrefs.GetFloat("FixJoystickYM"),0f), Quaternion.identity, canvas.transform);
            Obj.GetComponent<RectTransform>().anchorMax = new Vector2(0f,0f);
            Obj.GetComponent<RectTransform>().anchorMin = new Vector2(0f,0f);
            Obj.GetComponent<RectTransform>().pivot = new Vector2(0.5f,0.5f);
            Obj.tag = "MoveJoystick";
            Obj1 = Instantiate(Fixed, new Vector3(-L+PlayerPrefs.GetFloat("FixJoystickXF"), PlayerPrefs.GetFloat("FixJoystickYF"),0), Quaternion.identity, canvas.transform);
            Obj1.GetComponent<RectTransform>().anchorMax = new Vector2(1f,0f);
            Obj1.GetComponent<RectTransform>().anchorMin = new Vector2(1f,0f);
            Obj1.GetComponent<RectTransform>().pivot = new Vector2(0.5f,0.5f);
            Obj1.tag = "FireJoystick";
        }
        else
        {
            Obj = Instantiate(Floating, new Vector3(PlayerPrefs.GetFloat("OthJoystickXM"), PlayerPrefs.GetFloat("OthJoystickYM"),0), Quaternion.identity, canvas.transform);
            Obj.GetComponent<RectTransform>().anchorMax = new Vector2(0f,0f);
            Obj.GetComponent<RectTransform>().anchorMin = new Vector2(0f,0f);
            Obj.GetComponent<RectTransform>().pivot = new Vector2(0f,0f);
            Obj.tag = "MoveJoystick";
            Obj1 = Instantiate(Floating, new Vector3(-L+PlayerPrefs.GetFloat("OthJoystickXF"),PlayerPrefs.GetFloat("OthJoystickYF"),0), Quaternion.identity, canvas.transform);
            Obj1.GetComponent<RectTransform>().anchorMax = new Vector2(1f,0f);
            Obj1.GetComponent<RectTransform>().anchorMin = new Vector2(1f,0f);
            Obj1.GetComponent<RectTransform>().pivot = new Vector2(1f,0f);
            Obj1.tag = "FireJoystick";
        }/*
        else
        {
            Obj = Instantiate(Variable);
            Obj.transform.SetParent(canvas.transform);
            Obj.transform.position = new Vector3(0,0,0);
            Obj.GetComponent<RectTransform>().anchorMax = new Vector2(0f,0f);
            Obj.GetComponent<RectTransform>().anchorMin = new Vector2(0f,0f);
            Obj.GetComponent<RectTransform>().pivot = new Vector2(0f,0f);
            Obj.tag = "MoveJoystick";
            Obj1 = Instantiate(Variable);
            Obj1.transform.SetParent(canvas.transform);
            Obj1.transform.position = new Vector3(0,0,0);
            Obj1.GetComponent<RectTransform>().anchorMax = new Vector2(1f,0f);
            Obj1.GetComponent<RectTransform>().anchorMin = new Vector2(1f,0f);
            Obj1.GetComponent<RectTransform>().pivot = new Vector2(1f,0f);
            Obj1.tag = "FireJoystick";
        }*/
    }
    void FixedUpdate()
    {
        PlayerPrefs.SetFloat("ScaleJoystick", PlayerPrefs.GetFloat("ScaleJoystick")+Joy.Horizontal/100);
        Obj.transform.localScale = new Vector3(PlayerPrefs.GetFloat("ScaleJoystick"),PlayerPrefs.GetFloat("ScaleJoystick"),PlayerPrefs.GetFloat("ScaleJoystick"));
        Obj1.transform.localScale = new Vector3(PlayerPrefs.GetFloat("ScaleJoystick"),PlayerPrefs.GetFloat("ScaleJoystick"),PlayerPrefs.GetFloat("ScaleJoystick"));
    }
}
