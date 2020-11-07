using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MovePlayer : MonoBehaviour
{

    public  Joystick MoveJoystick;             //джостик перемещения
    public  Joystick FireJoystick;             //джостик стрельбы
    private float    MovePlayerHorizontal;     //переменная в которую записываеться значение положения джостика перемещения по горизонтали(ось X)
    private float    MovePlayerVertical;       //переменная в которую записываеться значение положения джостика перемещения по вертикали(ось Z)
    private float    FirePlayerHorizontal;     //переменная в которую записываеться значение положения джостика огня по вертикали(ось x)
    private float    FirePlayerVertical;       //переменная в которую записываеться значение положения джостика огня по вертикали(ось Z)
    private float    SpeedPlayerMove = 0.1f;   //скорость перемещения игрока
    private float    SpeedRotatePlayer = 100f; //скорость врщения игрока
    private Vector3  MoveVector;               //вектор вращение игрока и перемещения
    private Vector3  FireVector;               //вектор огня

    void FixedUpdate()
    {
        MovePlayerHorizontal = MoveJoystick.Horizontal;
        MovePlayerVertical = MoveJoystick.Vertical;
        FirePlayerHorizontal = FireJoystick.Horizontal;
        FirePlayerVertical = FireJoystick.Vertical;
        MoveVector = new Vector3(MovePlayerHorizontal, 0, MovePlayerVertical);
        FireVector = new Vector3(FirePlayerHorizontal, 0, FirePlayerVertical);
        transform.Translate(MoveVector * SpeedPlayerMove, Space.World);                //Перемещение игрока по вектору с опредеоенной скоростью
        if (FirePlayerHorizontal == 0 && FirePlayerVertical == 0)
        {
            transform.LookAt(MoveVector * SpeedRotatePlayer);                              //поворот игрока джостиком перемещения
        }
        else
        {
            transform.LookAt(FireVector * SpeedRotatePlayer);                           //поворот игрока джостиком огня
        }
    }
}
