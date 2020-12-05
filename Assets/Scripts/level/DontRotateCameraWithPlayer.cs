using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DontRotateCameraWithPlayer : MonoBehaviour
{
    private GameObject  wall;
    private bool        FuckYou = true;
    private int         Il;

    void FixedUpdate()
    {
        RaycastHit hit; //луч

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.gameObject.tag != "Player")
            {
                wall = hit.collider.gameObject;
                Color color = hit.collider.gameObject.GetComponent<MeshRenderer>().material.color;
                color.a = 0.5f;
                hit.collider.gameObject.GetComponent<MeshRenderer>().material.color = color;
                FuckYou = false;
                Il = 1;
            }
            else
            {
                FuckYou = true;
            }
        }
    }
    void Update()
    {
        if (wall!=null && FuckYou==true && Il == 1)
        {
            Color color = wall.GetComponent<MeshRenderer>().material.color;
            color.a = 1f;
            wall.GetComponent<MeshRenderer>().material.color = color;
            Il = 0;
        }
    }
}
