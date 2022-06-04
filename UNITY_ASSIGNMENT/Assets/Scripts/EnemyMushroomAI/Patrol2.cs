//This code belongs entirely to GDTitans and his series of videos on Youtube called Enemy AI in Unity.
//https://www.youtube.com/watch?v=CmzJtM5BIKE

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol2 : StateMachineBehaviour
{
    public float chaseRange = 10;
    float timer;
    List<Transform> wayPoints = new List<Transform>();
    NavMeshAgent agent;

    Transform player;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        Transform wayPointsParent = GameObject.FindGameObjectWithTag("Waypoints2").transform;
        foreach (Transform t in wayPointsParent)
        {
            wayPoints.Add(t);
        }

        agent = animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(wayPoints[0].position);

        player = GameObject.FindGameObjectWithTag("Player").transform;



    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
        }

        timer += Time.deltaTime;
        if (timer > 10)
        {
            animator.SetBool("isPatroling", false);
        }

        float distance = Vector3.Distance(animator.transform.position, player.position);

        if (distance < chaseRange)
        {
            animator.SetBool("isChasing", true);
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);

    }

}

