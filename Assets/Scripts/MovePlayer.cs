using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MovePlayer : MonoBehaviour
{

    public  Joystick   MoveJoystick;             //джостик перемещения
    public  Joystick   FireJoystick;             //джостик стрельбы
    private float      MovePlayerHorizontal;     //переменная в которую записываеться значение положения джостика перемещения по горизонтали(ось X)
    private float      MovePlayerVertical;       //переменная в которую записываеться значение положения джостика перемещения по вертикали(ось Z)
    private float      FirePlayerHorizontal;     //переменная в которую записываеться значение положения джостика огня по вертикали(ось x)
    private float      FirePlayerVertical;       //переменная в которую записываеться значение положения джостика огня по вертикали(ось Z)
    private float      SpeedPlayerMove = 0.1f;   //скорость перемещения игрока
    private float      DistanteRayCast = 10f;    //дальность стрельбы (луча raycast)
    private float      nextFire;                 //время между выстрелами
    private float      fireRate = 1;             //скорострельность
    private float      TimeSpawnBot = 5;         //время спавна ботов
    private Vector3    MoveVector;               //вектор вращение игрока и перемещения
    private Vector3    FireVector;               //вектор огня
    public  GameObject ZonaAttaki;               //зона атаки  
    public  GameObject Monster;                  //префаб монстра
    public  GameObject EffectPopadania;          //эффект попадания в цель


    /*void  Start()
    {
        InvokeRepeating("Shoot", 1f,5f);
    }*/
    void FixedUpdate()
    {
        TimeSpawnBot -= Time.deltaTime;
        MovePlayerHorizontal = MoveJoystick.Horizontal;
        MovePlayerVertical = MoveJoystick.Vertical;
        FirePlayerHorizontal = FireJoystick.Horizontal;
        FirePlayerVertical = FireJoystick.Vertical;
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
            if (Time.time > nextFire)
            {
                ZonaAttaki.SetActive(true);
                nextFire = Time.time + 1f / fireRate;
                Shoot();   
            }
        }
        else
        {
            ZonaAttaki.SetActive(false);
        }
        if (TimeSpawnBot < 0)
        {
            Instantiate(Monster);
            TimeSpawnBot = 5;
        }
    }
    void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, DistanteRayCast))
        {
            if (hit.collider.gameObject.tag=="Monster")
            {
                hit.collider.gameObject.GetComponent<MonsterMove>().HP -= 1;
                Instantiate(EffectPopadania, hit.point, Quaternion.identity);
            }
        }
        Debug.DrawRay(transform.position, transform.forward*DistanteRayCast, Color.red);
        Debug.Log("1");
    }
}
