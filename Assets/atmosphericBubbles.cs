using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atmosphericBubbles : MonoBehaviour {


    public GameObject bubblePrefab;
    public float range;
    public float frequency;
    private float timer;

	void Update () {
        timer += Time.deltaTime;
        if (timer > frequency)
        {
            Vector3 pos = Random.insideUnitSphere * range;
            pos.y = Mathf.Abs(pos.y);
            Instantiate(bubblePrefab, pos, Quaternion.Euler(0,Random.Range(0,360),0));
        }
		
	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(Vector3.zero, range);
    }
}
