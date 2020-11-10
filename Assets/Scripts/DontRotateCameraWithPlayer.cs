using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DontRotateCameraWithPlayer : MonoBehaviour
{
    public GameObject Player; //Игрок

    void FixedUpdate()
    {
        transform.position = new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z-7);           //перемещение камеры за игроком
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.gameObject.tag != "Player")
            {
                //hit.collider.gameObject.GetComponent<MeshRenderer>().material.color.a = 255;
                Debug.Log("You dont see player?");
            }
        }
    }
}
