using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patron : MonoBehaviour
{
    private float      SpeedPatron = 10;
    public  GameObject EffectPopadania;

    void Start()
    {
        Destroy(gameObject, 1f);
    }   
    void FixedUpdate()
    {
        transform.position += transform.forward * SpeedPatron * Time.deltaTime;
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Monster")
        {
            other.collider.gameObject.GetComponent<MonsterMove>().HP -= 1;
            Instantiate(EffectPopadania, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (other.gameObject.tag != "Monster" && other.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
