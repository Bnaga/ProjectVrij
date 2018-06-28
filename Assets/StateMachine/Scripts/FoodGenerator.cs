using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour {

    public GameObject food;
    public float mapSize = 2;
    public int rangemax = 250;
    public int randMax = 20;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        int rand = UnityEngine.Random.Range(0, rangemax);
        if (rand <= randMax)
        {
            Instantiate(food, transform.position + new Vector3(Random.Range(-mapSize,mapSize), Random.Range(0.25f,1),Random.Range(-mapSize, mapSize)), Quaternion.identity);
        }
    }
}
