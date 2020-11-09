using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMove : MonoBehaviour
{
    NavMeshAgent              agent;
    public       GameObject   Player;       //игрок
    public      float        HP = 3f;      //HP противника

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        agent = gameObject.GetComponent<NavMeshAgent>();
    }
    void FixedUpdate()
    {
        agent.SetDestination(Player.transform.position);      //задание места назначения для бота
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
