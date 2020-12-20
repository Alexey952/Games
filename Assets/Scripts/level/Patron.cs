using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patron : MonoBehaviour
{
    private float      SpeedPatron = 10;        //скорость патрон
    public  GameObject EffectPopadania;         //эффект попадания патроны во что-то

    void Start()
    {
        Destroy(gameObject, 1f);        //удаление через 1 секунду по спавна(можно регулировать дальность стрельбы)
    }   
    void FixedUpdate()
    {
        transform.position += transform.forward * SpeedPatron * Time.deltaTime;     //перемещение
    }
    void OnTriggerEnter(Collider other)      //столкновение с разными обьектами(враг или стена)
    {
        if (other.gameObject.tag == "Monster")
        {
            other.gameObject.GetComponent<MonsterMove>().HP -= 1;
            Instantiate(EffectPopadania, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Untagged")
        {
            Instantiate(EffectPopadania, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
