using UnityEngine;
using System.Collections;

public class GlobalFlock : MonoBehaviour {


	public GameObject defaultFish;
	public GameObject[] fishPrefabs;
	public GameObject fishSchool;
	public static int tankSize = 4;
    public static Vector3 defaultPos;

static int numFish = 40;
	public static GameObject[] allFish = new GameObject[numFish];
	public static Vector3 goalPos = Vector3.zero;

	// Use this for initialization
	void Start () {
        defaultPos = transform.position;
		for (int i = 0; i < numFish; i++) {
			Vector3 pos;
            int j = 0;
            do{
                
                pos= new Vector3 (
                    Random.Range(-tankSize, tankSize),
                    Random.Range(1, tankSize),
                    Random.Range(-tankSize, tankSize)
                );
                j++;
                if (j>20){
                    Debug.Log("could not find place for fish");
                    break;
                }

            }while(pos != checkPos(pos));
			GameObject fish = (GameObject)Instantiate (
				fishPrefabs[Random.Range (0, fishPrefabs.Length)], pos, Quaternion.identity);
			fish.transform.parent = fishSchool.transform;
			allFish [i] = fish;
		}
	}
	
	// Update is called once per frame
	void Update () {
		HandleGoalPos ();
	}

	void HandleGoalPos() {
		if (Random.Range(1, 10000) < 50) {
			goalPos = new Vector3 (
				Random.Range(-tankSize, tankSize),
				Random.Range(0, tankSize*2),
				Random.Range(-tankSize, tankSize)
			);
            goalPos = checkPos(goalPos);
           
		}
	}

    Vector3 checkPos(Vector3 input){
        RaycastHit hit;
        if (Physics.Raycast(transform.position,input, out hit)){
            return(hit.point - (goalPos - hit.point)/10);
            }
            return input;
    }
}