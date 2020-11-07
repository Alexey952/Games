using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MovePlayer : MonoBehaviour
{

    public  Joystick MoveJoystick;             //сам джостик
    private float    MovePlayerHorizontal;     //переменная в которую записываеться значение положения джостика по горизонтали(ось X)
    private float    MovePlayerVertical;       //переменная в которую записываеться значение положения джостика по вертикали(ось Z)
    private float    SpeedPlayerMove = 0.1f;    //скорость перемещения игрока
    private float    SpeedRotatePlayer = 100f; //скорость врщения игрока
    private Vector3  MoveVector;               //вектор вращение игрока и перемещения

    void FixedUpdate()
    {
        MovePlayerHorizontal = MoveJoystick.Horizontal;
        MovePlayerVertical = MoveJoystick.Vertical;
        MoveVector = new Vector3(MovePlayerHorizontal, 0, MovePlayerVertical);
        transform.Translate(MoveVector* SpeedPlayerMove, Space.World);
        transform.LookAt(MoveVector* SpeedRotatePlayer);
    }
}
