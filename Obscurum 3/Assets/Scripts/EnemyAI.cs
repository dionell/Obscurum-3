using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float health;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.enabled == true)
        {
            agent.SetDestination(target.position);
        }
    }
}
