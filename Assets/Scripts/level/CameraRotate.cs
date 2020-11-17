using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public  GameObject Player; //Игрок
    private float      speed;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }
    void FixedUpdate()
    {
        speed = PlayerPrefs.GetFloat("SliderCamera");
        transform.Rotate(new Vector3(0, speed * 50, 0) * Time.deltaTime);
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);           //перемещение камеры за игроком
    }
}
