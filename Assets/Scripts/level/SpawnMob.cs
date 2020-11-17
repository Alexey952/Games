using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMob : MonoBehaviour
{
    private float           TimeSpawnBot = 5f;             //время спавна ботов
    public  GameObject      Monster;                      //префаб монстра

    void FixedUpdate()
    {
        TimeSpawnBot -= Time.deltaTime;
        if (TimeSpawnBot < 0)                   //спавн ботов
        {
            Instantiate(Monster);
            TimeSpawnBot = 5f;
        }
    }
}
