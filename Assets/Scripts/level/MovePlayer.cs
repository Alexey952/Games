using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class MovePlayer : MonoBehaviour
{

    private Joystick        MoveJoystick;                 //джостик перемещения
    private Joystick        FireJoystick;                 //джостик стрельбы
    private float           MovePlayerHorizontal;         //переменная в которую записываеться значение положения джостика перемещения по горизонтали(ось X)
    private float           MovePlayerVertical;           //переменная в которую записываеться значение положения джостика перемещения по вертикали(ось Z)
    private float           FirePlayerHorizontal;         //переменная в которую записываеться значение положения джостика огня по вертикали(ось x)
    private float           FirePlayerVertical;           //переменная в которую записываеться значение положения джостика огня по вертикали(ось Z)
    private float           SpeedPlayerMove = 0.1f;       //скорость перемещения игрока
    //private float           DistanteRayCast = 10f;    //дальность стрельбы (луча raycast)
    private float           nextFire;                     //время между выстрелами
    private float           fireRate = 1;                 //скорострельность
    private float           TimeReloading = 2;            //время перезарядки оружия
    private float           X1;
    private float           Z1;
    private float           L;
    private int             PatronInMagazin = 6;          //патроны в магазине
    private int             Magazin = 10;                 //кол_во магазинов
    private int             MoneyInThisGame;              //деньги
    private double          Cosi;
    private double          Sini;
    private bool            TimeReloadingMagazin = false; //когда прекратить перезарядку
    private bool            BoolScene = true;
    private string          WhatScene;
    private Vector3         MoveVector;                   //вектор вращение игрока и перемещения
    private Vector3         FireVector;                   //вектор огня
    public  GameObject      ZonaAttaki;                   //зона атаки    
    public  GameObject      EffectPopadania;              //эффект попадания в цель
    public  GameObject      Patron;                       //префаб патрона
    public  GameObject      WeaponImage;                  //кнопка смены оружия
    public  GameObject      ContinueButton;               //кнопка прожолжнния игру по нажатия паузы
    public  GameObject      VolumText;
    private GameObject      VolumSlider;
    private GameObject      SoundsSlider;
    private GameObject      RotCamera;
    private GameObject      LOX;
    private GameObject      Obj;
    public  GameObject      Dinamic;
    public  GameObject      Fixed;
    public  GameObject      Floating;
    public  GameObject      Variable;
    private GameObject      canvas;
    public  TextMeshProUGUI PatronShow;                   //показатель кол-ва патрон
    public  TextMeshProUGUI Money;                        //показывает кол-во денег
    public  Sprite          spr1,spr3;                    //спрайты оружия



    void  Start()
    {
        foreach (var res in Screen.resolutions)
        {
            L = res.width;
        }
        //InvokeRepeating("Shoot", 1f,5f);
        WhatScene = SceneManager.GetActiveScene().name;
        if (WhatScene == "Main" || WhatScene == "JoystickSettings")
        {
            BoolScene = false;
        }
        else
        {
            PlayerPrefs.SetInt("MoneyInGame", 0);
        }
        if (WhatScene != "JoystickSettings")
        {
            canvas = GameObject.FindGameObjectWithTag("canvas");
            if (PlayerPrefs.GetInt("Joystick") == 0)
            {
                Obj = Instantiate(Dinamic, new Vector3(PlayerPrefs.GetFloat("OthJoystickXM"), PlayerPrefs.GetFloat("OthJoystickYM"),0), Quaternion.identity, canvas.transform);
                Obj.GetComponent<RectTransform>().anchorMax = new Vector2(0f,0f);
                Obj.GetComponent<RectTransform>().anchorMin = new Vector2(0f,0f);
                Obj.GetComponent<RectTransform>().pivot = new Vector2(0f,0f);
                Obj.tag = "MoveJoystick";
                Obj.transform.localScale = new Vector3(PlayerPrefs.GetFloat("ScaleJoystick"),PlayerPrefs.GetFloat("ScaleJoystick"),PlayerPrefs.GetFloat("ScaleJoystick"));
                Obj = Instantiate(Dinamic, new Vector3(-L+PlayerPrefs.GetFloat("OthJoystickXF"), PlayerPrefs.GetFloat("OthJoystickYF"),0), Quaternion.identity, canvas.transform);
                Obj.GetComponent<RectTransform>().anchorMax = new Vector2(1f,0f);
                Obj.GetComponent<RectTransform>().anchorMin = new Vector2(1f,0f);
                Obj.GetComponent<RectTransform>().pivot = new Vector2(1f,0f);
                Obj.tag = "FireJoystick";
                Obj.transform.localScale = new Vector3(PlayerPrefs.GetFloat("ScaleJoystick"),PlayerPrefs.GetFloat("ScaleJoystick"),PlayerPrefs.GetFloat("ScaleJoystick"));
            }
            else if (PlayerPrefs.GetInt("Joystick") == 1)
            {
                Obj = Instantiate(Fixed, new Vector3(PlayerPrefs.GetFloat("FixJoystickXM"), PlayerPrefs.GetFloat("FixJoystickYM"),0f), Quaternion.identity, canvas.transform);
                Obj.GetComponent<RectTransform>().anchorMax = new Vector2(0f,0f);
                Obj.GetComponent<RectTransform>().anchorMin = new Vector2(0f,0f);
                Obj.GetComponent<RectTransform>().pivot = new Vector2(0f,0f);
                Obj.tag = "MoveJoystick";
                Obj.transform.localScale = new Vector3(PlayerPrefs.GetFloat("ScaleJoystick"),PlayerPrefs.GetFloat("ScaleJoystick"),PlayerPrefs.GetFloat("ScaleJoystick"));
                Obj = Instantiate(Fixed, new Vector3(-L+PlayerPrefs.GetFloat("FixJoystickXF"), PlayerPrefs.GetFloat("FixJoystickYF"),0), Quaternion.identity, canvas.transform);
                Obj.GetComponent<RectTransform>().anchorMax = new Vector2(1f,0f);
                Obj.GetComponent<RectTransform>().anchorMin = new Vector2(1f,0f);
                Obj.GetComponent<RectTransform>().pivot = new Vector2(1f,0f);
                Obj.tag = "FireJoystick";
                Obj.transform.localScale = new Vector3(PlayerPrefs.GetFloat("ScaleJoystick"),PlayerPrefs.GetFloat("ScaleJoystick"),PlayerPrefs.GetFloat("ScaleJoystick"));
            }
            else
            {
                Obj = Instantiate(Floating, new Vector3(PlayerPrefs.GetFloat("OthJoystickXM"), PlayerPrefs.GetFloat("OthJoystickYM"),0), Quaternion.identity, canvas.transform);
                Obj.GetComponent<RectTransform>().anchorMax = new Vector2(0f,0f);
                Obj.GetComponent<RectTransform>().anchorMin = new Vector2(0f,0f);
                Obj.GetComponent<RectTransform>().pivot = new Vector2(0f,0f);
                Obj.tag = "MoveJoystick";
                Obj.transform.localScale = new Vector3(PlayerPrefs.GetFloat("ScaleJoystick"),PlayerPrefs.GetFloat("ScaleJoystick"),PlayerPrefs.GetFloat("ScaleJoystick"));
                Obj = Instantiate(Floating, new Vector3(-L+PlayerPrefs.GetFloat("OthJoystickXF"),PlayerPrefs.GetFloat("OthJoystickYF"),0), Quaternion.identity, canvas.transform);
                Obj.GetComponent<RectTransform>().anchorMax = new Vector2(1f,0f);
                Obj.GetComponent<RectTransform>().anchorMin = new Vector2(1f,0f);
                Obj.GetComponent<RectTransform>().pivot = new Vector2(1f,0f);
                Obj.tag = "FireJoystick";
                Obj.transform.localScale = new Vector3(PlayerPrefs.GetFloat("ScaleJoystick"),PlayerPrefs.GetFloat("ScaleJoystick"),PlayerPrefs.GetFloat("ScaleJoystick"));
            }
            WeaponImage = GameObject.FindGameObjectWithTag("Weapon");
            VolumText = GameObject.FindGameObjectWithTag("TextVol");
            VolumSlider = GameObject.FindGameObjectWithTag("VolSlid");
            SoundsSlider = GameObject.FindGameObjectWithTag("SoundSlid");
            ContinueButton = GameObject.FindGameObjectWithTag("Continue");
            ContinueButton.SetActive(false);
            VolumText.SetActive(false);
            VolumSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MusicVolum");
            SoundsSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("SoundsVolume");
            VolumSlider.SetActive(false);
            SoundsSlider.SetActive(false);
        }
        PlayerPrefs.SetFloat("PlayerHPnow", PlayerPrefs.GetFloat("PlayerHP"));
        RotCamera = GameObject.FindGameObjectWithTag("RotCamera");
        if (WhatScene != "JoystickSettings")
        {
            LOX = GameObject.FindGameObjectWithTag("MoveJoystick");
            MoveJoystick = LOX.GetComponent<Joystick>();
            LOX = GameObject.FindGameObjectWithTag("FireJoystick");
            FireJoystick = LOX.GetComponent<Joystick>();
        }
    }
    void FixedUpdate()
    {
        if (WhatScene == "JoystickSettings")
        {
            LOX = GameObject.FindGameObjectWithTag("MoveJoystick");
            MoveJoystick = LOX.GetComponent<Joystick>();
            LOX = GameObject.FindGameObjectWithTag("FireJoystick");
            FireJoystick = LOX.GetComponent<Joystick>();
        }
        if (PlayerPrefs.GetFloat("PlayerHPnow") <= 0)
        {
            PlayerPrefs.SetInt("SceneLoading", 2);
            SceneManager.LoadScene(1);
        }
        MovePlayerHorizontal = MoveJoystick.Horizontal;              //считывание показаний с джостика
        MovePlayerVertical = MoveJoystick.Vertical;                  //тоже
        FirePlayerHorizontal = FireJoystick.Horizontal;              //и это
        FirePlayerVertical = FireJoystick.Vertical;                  //ага
        if (Input.GetKey("w")){                                      //движение по клавиатуре, пару строчек в низ
            MovePlayerVertical = 1f;
        }
        if (Input.GetKey("s")){
            MovePlayerVertical = -1f;
        }
        if (Input.GetKey("a")){
            MovePlayerHorizontal = -1f;
        }
        if (Input.GetKey("d")){
            MovePlayerHorizontal = 1f;
        }
        MoveVector = new Vector3(MovePlayerHorizontal, 0, MovePlayerVertical);
        FireVector = new Vector3(FirePlayerHorizontal, 0, FirePlayerVertical);
        transform.Translate(MoveVector * SpeedPlayerMove, RotCamera.transform);                //Перемещение игрока по вектору с опредеоенной скоростью
        if ((FirePlayerHorizontal == 0f && FirePlayerVertical == 0f) && (MovePlayerHorizontal != 0f && MovePlayerVertical != 0f))
        {
            Sini = Math.Sin(RotCamera.transform.rotation.eulerAngles.y*Math.PI/180);
            Cosi = Math.Cos(RotCamera.transform.rotation.eulerAngles.y*Math.PI/180);
            X1 = (float)Math.Round((MoveVector.x*Cosi + MoveVector.z*Sini), 2);
            Z1 = (float)Math.Round((MoveVector.z*Cosi - MoveVector.x*Sini), 2);
            MoveVector.x = X1;
            MoveVector.z = Z1;
            transform.rotation = Quaternion.LookRotation(MoveVector, Vector3.up);                             //поворот игрока джостиком перемещения
        }
        else if (FirePlayerHorizontal != 0f && FirePlayerVertical != 0f)
        {
            Sini = Math.Sin(RotCamera.transform.rotation.eulerAngles.y*Math.PI/180);
            Cosi = Math.Cos(RotCamera.transform.rotation.eulerAngles.y*Math.PI/180);
            X1 = (float)Math.Round((FireVector.x*Cosi + FireVector.z*Sini), 2);
            Z1 = (float)Math.Round((FireVector.z*Cosi - FireVector.x*Sini), 2);
            FireVector.x = X1;
            FireVector.z = Z1;
            transform.rotation = Quaternion.LookRotation(FireVector, Vector3.up);                          //поворот игрока джостиком огня
            if (BoolScene)
            {
                ZonaAttaki.SetActive(true);
                Shoot();
            }
        }
        else
        {
            ZonaAttaki.SetActive(false);
        } 
        if (TimeReloadingMagazin)  //перезарядка
        {
            TimeReloading -= Time.deltaTime;
            if (TimeReloading < 0)
                    {
                        if (Magazin > 0)
                        {
                           Magazin -- ;
                        PatronInMagazin = 6;
                        }
                        TimeReloading = 2;
                        TimeReloadingMagazin = false;
                    }
        }
        if (BoolScene)
        {
            MoneyInThisGame = PlayerPrefs.GetInt("MoneyInGame");    //считывание денег
        }
        else
        {
            MoneyInThisGame = PlayerPrefs.GetInt("AllMoney"); 
        }
        if (WhatScene != "JoystickSettings")
        {
            Money.text = MoneyInThisGame + " ";                    //вывод денег на экран
            PatronShow.text = PatronInMagazin + "/" + Magazin;
        }
    }
    void Shoot()        //функция стрельбы
    {
        if (Time.time > nextFire)                                                                      //стрельба                                                                         
        {
            nextFire = Time.time + 1f / fireRate;
            if (PatronInMagazin > 0)
            {
                Instantiate(Patron, transform.position, Quaternion.LookRotation(FireVector, Vector3.up));
                PatronInMagazin -- ;
            }
        }
        if (PatronInMagazin == 0)   
        {
            TimeReloadingMagazin = true;
        }                                                                                           
        /*
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, DistanteRayCast))
        {
            if (hit.collider.gameObject.tag=="Monster")
            {
                //hit.collider.gameObject.GetComponent<MonsterMove>().HP -= 1;
                //Instantiate(EffectPopadania, hit.point, Quaternion.identity);
            }
        }
        */
    }
    public void WeaponImages()          //функция смены оружия
    {
        if (WeaponImage.GetComponent<Image>().sprite == spr1)
        {
            WeaponImage.GetComponent<Image>().sprite = spr3;
        }
        else
        {
            WeaponImage.GetComponent<Image>().sprite = spr1;
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
