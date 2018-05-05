using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalFlock : MonoBehaviour {

    public GameObject fish;
    public static int tankSize = 4;
    public static int tankMin = 0;

    static int numFish = 15;
    public static GameObject[] allFIsh = new GameObject[numFish];

    public static Vector3 goalPos = Vector3.zero;

	// Use this for initialization
	void Start ()
    {
        //tankMin = -tankSize;
		for(int i = 0; i < numFish; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-tankSize, tankSize),
                                      Random.Range(tankMin, tankSize*2),
                                      Random.Range(-tankSize, tankSize));
            allFIsh[i] = (GameObject) Instantiate(fish, pos, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Random.Range(0,10000) < 50)
        {
            goalPos = new Vector3(Random.Range(-tankSize, tankSize),
                                  Random.Range(tankMin, tankSize * 2),
                                  Random.Range(-tankSize, tankSize));
        }
	}
}
