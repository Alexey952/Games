using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DontRotateCameraWithPlayer : MonoBehaviour
{
    private GameObject       wall;
    private bool             FuckYou = true;
    private int              Il;
    private List<GameObject> walls;
    void Start()
    {
        walls = new List<GameObject>();
    }
    void FixedUpdate()
    {
        RaycastHit hit; //луч
        
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.gameObject.tag != "Player")
            {
                wall = hit.collider.gameObject;
                if (!walls.Contains(wall))
                    walls.Add(wall);
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
        if (walls.Count != 0 && FuckYou==true && Il == 1)
        {
            for (int i = walls.Count-1; i > -1; i--)
            {
                Color color = walls[i].GetComponent<MeshRenderer>().material.color;
                color.a = 1f;
                walls[i].GetComponent<MeshRenderer>().material.color = color;
            }
            walls.Clear();
            Il = 0;
        }
    }
}
