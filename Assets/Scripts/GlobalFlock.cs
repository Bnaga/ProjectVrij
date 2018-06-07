using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalFlock : MonoBehaviour {

    public GameObject[] fishObj;
    public static int tankSize = 5;
    public static int tankMin = 0;

    static int numFish = 30;
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
            GameObject obj = fishObj[Random.Range(0,fishObj.Length)];
            allFIsh[i] = (GameObject) Instantiate(obj, pos, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Random.Range(0,10000) < 50) newGoal(transform.position);

		
          
	}

	public static void newGoal(Vector3 origin){
		  goalPos = new Vector3(Random.Range(-tankSize, tankSize),
                                  Random.Range(tankMin, tankSize * 2),
                                  Random.Range(-tankSize, tankSize));
								   RaycastHit hit;
        if (Physics.Raycast(origin,goalPos, out hit)){
            goalPos = (goalPos + hit.point*9)/10;

	    }

    }
}
