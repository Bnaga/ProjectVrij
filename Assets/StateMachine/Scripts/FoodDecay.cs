using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDecay : MonoBehaviour {

    public float foodDecay = 10;
    private float decayTimer;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
    {
        decayTimer += Time.deltaTime;
        if(decayTimer >= foodDecay)
        {
            Destroy(this.gameObject);
        }
	}
}
