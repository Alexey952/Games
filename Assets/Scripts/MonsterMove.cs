using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMove : MonoBehaviour
{
    [SerializeField]            //это чтобы видеть agent в инспекторе
    NavMeshAgent agent;
    public GameObject Player;

    void FixedUpdate()
    {
        agent.SetDestination(Player.transform.position);      //задание места назначения для бота
    }
}
