using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class mojiliMovement : MonoBehaviour {

	private UnityEngine.AI.NavMeshAgent agent;
	private Coroutine Wandering;
	// Use this for initialization
	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		Wandering = StartCoroutine(Wander());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	 public Vector3 RandomNavmeshLocation(float radius) {
         Vector3 randomDirection = Random.insideUnitSphere * radius;
         randomDirection += transform.position;
         UnityEngine.AI.NavMeshHit hit;
         Vector3 finalPosition = Vector3.zero;
         if (UnityEngine.AI.NavMesh.SamplePosition(randomDirection, out hit, radius, 1)) {
             finalPosition = hit.position;            
         }
         return finalPosition;
     }

	 IEnumerator Wander() {
		 while(true) 
         { 
             agent.SetDestination(RandomNavmeshLocation(2f));
             yield return new WaitForSeconds(Random.Range(3f,5f));
         }
    }
}

