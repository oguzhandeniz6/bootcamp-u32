using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Vector3 destination;
    public Transform Player;
    public Transform[] waypoints;
    public NavMeshAgent agent;
    public GameObject cube;
    public bool spotted;
    public float searchTime;

    int destPoint = 0;
    
    void Update(){
        if(spotted == false){
            cube.SetActive(false);
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();
        }
        if(spotted == true){
            cube.SetActive(true);
            destination = Player.position;
            agent.destination = destination;
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            spotted = true;
        }
    }

    void OnTriggerExit(Collider other){
        if(other.CompareTag("Player")){
            StartCoroutine(search());
        }
    }

    IEnumerator search(){
        yield return new WaitForSeconds(searchTime);
        spotted = false;
    }

    void GotoNextPoint() {
        // Returns if no points have been set up
        if (waypoints.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = waypoints[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % waypoints.Length;
    }
}
