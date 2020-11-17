using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class MovePlayer : MonoBehaviour
{

    public  Joystick        MoveJoystick;                 //джостик перемещения
    public  Joystick        FireJoystick;                 //джостик стрельбы
    private float           MovePlayerHorizontal;         //переменная в которую записываеться значение положения джостика перемещения по горизонтали(ось X)
    private float           MovePlayerVertical;           //переменная в которую записываеться значение положения джостика перемещения по вертикали(ось Z)
    private float           FirePlayerHorizontal;         //переменная в которую записываеться значение положения джостика огня по вертикали(ось x)
    private float           FirePlayerVertical;           //переменная в которую записываеться значение положения джостика огня по вертикали(ось Z)
    private float           SpeedPlayerMove = 0.1f;       //скорость перемещения игрока
    //private float           DistanteRayCast = 10f;    //дальность стрельбы (луча raycast)
    private float           nextFire;                     //время между выстрелами
    private float           fireRate = 1;                 //скорострельность
    private float           TimeReloading = 2;            //время перезарядки оружия
    private int             PatronInMagazin = 6;          //патроны в магазине
    private int             Magazin = 10;                 //кол_во магазинов
    private int             MoneyInThisGame;              //деньги
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
    public  GameObject      VolumSlider;
    public  TextMeshProUGUI PatronShow;                   //показатель кол-ва патрон
    public  TextMeshProUGUI Money;                        //показывает кол-во денег
    public  Sprite          spr1,spr3;                    //спрайты оружия



    void  Start()
    {
        VolumSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MusicVolum");
        //InvokeRepeating("Shoot", 1f,5f);
        WhatScene = SceneManager.GetActiveScene().name;
        if (WhatScene == "Main")
        {
            BoolScene = false;
        }
        else
        {
            PlayerPrefs.SetInt("MoneyInGame", 0);
        }
        WeaponImage = GameObject.FindGameObjectWithTag("Weapon");
        VolumText = GameObject.FindGameObjectWithTag("TextVol");
        VolumSlider = GameObject.FindGameObjectWithTag("VolSlid");
        ContinueButton = GameObject.FindGameObjectWithTag("Continue");
        ContinueButton.SetActive(false);
        VolumSlider.SetActive(false);
        VolumText.SetActive(false);
    }
    void FixedUpdate()
    {
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
        transform.Translate(MoveVector * SpeedPlayerMove, Space.World);                //Перемещение игрока по вектору с опредеоенной скоростью
        if ((FirePlayerHorizontal == 0f && FirePlayerVertical == 0f) && (MovePlayerHorizontal != 0f && MovePlayerVertical != 0f))
        {
            transform.rotation = Quaternion.LookRotation(MoveVector, Vector3.up);                             //поворот игрока джостиком перемещения
        }
        else if (FirePlayerHorizontal != 0f && FirePlayerVertical != 0f)
        {
            transform.rotation = Quaternion.LookRotation(FireVector, Vector3.up);                          //поворот игрока джостиком огня
            if (BoolScene)
            {
                ZonaAttaki.SetActive(true);
                if (Time.time > nextFire)                                                                      //стрельба                                                                         
                {
                    nextFire = Time.time + 1f / fireRate;
                    if (PatronInMagazin > 0)
                    {
                        Shoot();
                        PatronInMagazin -- ;
                    }
                    else if (PatronInMagazin == 0)
                    {
                        TimeReloadingMagazin = true;
                    }                                                                                           //тут все сложно
            }
            }
        }
        else
        {
            ZonaAttaki.SetActive(false);
        }
        PatronShow.text = PatronInMagazin + "/" + Magazin; 
        if (TimeReloadingMagazin)
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
        Money.text = MoneyInThisGame + " ";                    //вывод денег на экран
    }
    void Shoot()        //функция стрельбы
    {
        Instantiate(Patron, transform.position, Quaternion.LookRotation(FireVector, Vector3.up));
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
    }
    public void Continue()                  //продолжение
    {
        Time.timeScale = 1;
        ContinueButton.SetActive(false);
        VolumSlider.SetActive(false);
        VolumText.SetActive(false);
    }/*
    public void Joystick()
    {
        if ((-0.5f<FirePlayerHorizontal) && (0.5f>FirePlayerHorizontal) && (-0.5f<FirePlayerVertical) && (0.5f>FirePlayerVertical))
        {
            Debug.Log("dhdgjdtj");
        }
    }*/
    public void SetVolum(float vol)
    {
        PlayerPrefs.SetFloat("MusicVolum", vol);
    }
}
