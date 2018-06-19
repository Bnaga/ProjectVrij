using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour {

    public GameObject food;
    public float mapSize = 2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        int rand = UnityEngine.Random.Range(0, 500);
        if (rand <= 10)
        {
            Instantiate(food, new Vector3(Random.Range(-mapSize,mapSize), Random.Range(0.25f,1),Random.Range(-mapSize, mapSize)), Quaternion.identity);
        }
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(food, new Vector3(Random.Range(-mapSize, mapSize), Random.Range(0.25f, 1), Random.Range(-mapSize, mapSize)), Quaternion.identity);
        }
    }
}
