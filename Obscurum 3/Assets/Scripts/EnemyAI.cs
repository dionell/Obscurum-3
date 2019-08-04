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

    public float lookRadius = 10f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        target = PlayerManager.instance.player.transform;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(agent.enabled == true)
        {
            if(distance <= lookRadius)
            {
                agent.isStopped = false;
                anim.SetBool("Run", true);
                agent.SetDestination(target.position);

                if(distance <= agent.stoppingDistance)
                {
                    anim.SetTrigger("Attack");
                    FaceTarget();
                    Debug.Log("stop");
                    anim.SetBool("Run", false);
                }
            }
            else
            {
                agent.isStopped = true;
                anim.SetBool("Run", false);
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
