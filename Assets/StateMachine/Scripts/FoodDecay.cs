using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDecay : MonoBehaviour {

    public float foodDecay = 10;
    private float decayTimer;
    public bool pickedUp = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!pickedUp)
        {
            decayTimer += Time.deltaTime;
        }
        if(pickedUp)
        {
            decayTimer = 0;
        }
        if(decayTimer >= foodDecay)
        {
            Destroy(this.gameObject);
        }
	}
}
