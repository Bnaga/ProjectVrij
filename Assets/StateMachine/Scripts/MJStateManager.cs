using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MJStateManager : MonoBehaviour {

    public Transform eyes;
    public State currentState;
    public State remainState;

    public fishDictionary dictionary;
    [HideInInspector]
    public soundCommunication soundCommunication;

    public int curState = 0;
    public int tempState = 0;
    public int waitSec = 15;
    public float interMax = 10;
    public float coolDownMax = 10;

    public bool hide = false;
    public bool inDanger = false;
    public bool onDestination = true;
    public bool hasFood = false;
    public bool isInteracting = false;
    public bool isTalking = false;
    public bool isFollowing = false;
    public bool isMakingMusic = false;
    public bool otherIsLeader = false;
    public bool waitIsOver = false;
    public bool isSpokenTo = false;
    public bool isSpeaking = false;
    public bool onIntDestination = false;
    public bool coolDown = false;

    float interactionTimer = 0;
    float interactionCoolDown = 0;

    public bool isInteractor = false;
    public bool isInteractee = false;

    public GameObject interactionTarget;
    public GameObject Leader;
    public GameObject followTarget;

    [HideInInspector] public NavMeshAgent navMeshAgent;
	// Use this for initialization
	void Awake ()
    {
        curState = 0;
        navMeshAgent = GetComponent<NavMeshAgent>();
        onDestination = true;
        soundCommunication = GetComponent<soundCommunication>();
        //navMeshAgent.destination = Vector3.zero;
	}

    private void Start()
    {
     hide = false;
     inDanger = false;
     onDestination = true;
     hasFood = false;
     isInteracting = false;
     isTalking = false;
     isFollowing = false;
     isMakingMusic = false;
     otherIsLeader = false;
     waitIsOver = false; 
     isInteractor = false;
     isInteractee = false;
     interactionTarget = gameObject;
    }

    private void Update()
    {
        currentState.UpdateState(this);
        StartCoolDown();
        soundResponse();
    }


    private void soundResponse(){
        List <fishDictionary.word> words = soundCommunication.receivedWords;
        if (words.Count>0){
            foreach (fishDictionary.word word in words){
                if (word.Name == "music"){
                    curState = 13;
                }
                if( word.Name == "followme")
                {
                   // Debug.Log("follow me");
                    curState = 14; //follow state
                    followTarget = interactionTarget;
                    isFollowing = true;
                }
                if(word.Name == "greeting")
                {
                    curState = 11;
                }
                if(word.Name == "alert")
                {
                    curState = 15; //flight state
                }
                if(word.Name == "smallTalk")
                {
                    curState = 11;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (currentState != null)
        {
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere(transform.position, 0.1f);
        }

    }

    public void TransitionToState(State nextState)
    {
        if(nextState != remainState)
        {
            currentState = nextState;
        }
    }

    #region randomStates
    public void RandomState()
    {
        tempState = Random.Range(1, 101);
        if(tempState < 81)
        {
            curState = 1; //wandering state
        }
        if(tempState >= 81 && tempState <85)
        {
            curState = 2; //go home state
        }
        if (tempState >= 85 && tempState < 90)
        {
            curState = 3;  //go to neighbor
        }
        if (tempState >= 90 && tempState < 95)
        {
            curState = 4; //exploration state
        }
        if (tempState >= 95 && tempState <= 100)
        {
            curState = 5; //music state
        }
    }

    public void RandomSoldierState()
    {
        tempState = Random.Range(0, 10);
        if (tempState < 9)
        {
            curState = 6; // leader/soldier wander
        }
        if (tempState == 9)
        {
            curState = 7; // go to nearest mojili
        }
    }

    public void RandomFarmerState()
    {
        tempState = Random.Range(0, 2);
        if (tempState == 0)
        {
            curState = 8; // get food state
        }
        if (tempState == 1)
        {
            RandomState();
        }
    }
    
    #endregion

    #region interaction
    public void LeaderInteraction()
    {
        tempState = Random.Range(0, 4);
        if (tempState < 3)
        {
            curState = 9; // assign new role state
        }
        if (tempState == 3)
        {
            curState = 10; //follow me state
        }
    }

    public void RandomInteraction()
    {
        tempState = Random.Range(0, 10);
        if (tempState < 6)
        {
            curState = 11; //talk state
        }
        if (tempState >=6 && tempState <8)
        {
            curState = 12; //send to leader state
        }
        if (tempState > 8)
        {
            curState = 10; //follow me state
        }

    }

    public void RandomsInteraction()
    {
        tempState = Random.Range(0, 10);
        if (tempState < 6)
        {
            curState = 11; //talk state
        }
        if (tempState >= 6)
        {
            curState = 10; //follow me state
        }
    }

        public void MusicInteraction()
    {
        tempState = Random.Range(1, 101);
        if (tempState < 86)
        {
            curState = 13; //dance state
        }
        if (tempState >= 86)
        {
            curState = 5; //music state
        }
    }
    #endregion

    
    #region trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Mojili")
        {
            interactionTarget = null;
            //Debug.Log("trigger" + other.name);
            if (this.interactionTarget == null && other.gameObject.GetComponent<MJStateManager>().interactionTarget == null)
            {
                other.gameObject.GetComponent<MJStateManager>().isInteracting = true;
                isInteracting = true;
                other.gameObject.GetComponent<MJStateManager>().interactionTarget = this.gameObject;
                interactionTarget = other.gameObject;
                onDestination = true;
                other.GetComponent<MJStateManager>().navMeshAgent.SetDestination(other.transform.position);
                other.GetComponent<MJStateManager>().onDestination = true;
                other.GetComponent<MJStateManager>().interactionTarget = this.gameObject;
                isInteractor = true;
                other.gameObject.GetComponent<MJStateManager>().isInteractee = true;
            }

        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Mojili")
        {
                other.gameObject.GetComponent<MJStateManager>().isInteracting = false;
                isInteracting = false;
                other.gameObject.GetComponent<MJStateManager>().interactionTarget = null;
                interactionTarget = null;
                isInteractor = false;
                other.gameObject.GetComponent<MJStateManager>().isInteractee = false;
        }

    }
    #endregion
    
    

    public void StartInteractiontimer()
    {
        interactionTimer += Time.deltaTime;
        if(interactionTimer >= interMax )
        {
            coolDown = true;
            interactionTimer = 0;
        }
    }

    public void StartCoolDown()
    {
        if (coolDown)
        {
            interactionCoolDown += Time.deltaTime;
            if(interactionCoolDown >= coolDownMax)
            {
                coolDown = false;
                interactionCoolDown = 0;
            }
            
        }
    }


    IEnumerator CoolDownTimer()
    {
        yield return new WaitForSeconds(waitSec);
        coolDown = false;
    }

    public void AudioAction(string tag){

        foreach (fishDictionary.word word in dictionary.dictionary){
            if (word.Name == tag){
                soundCommunication.playWord(word, dictionary);
                Debug.DrawLine(transform.position,transform.position + transform.up,Color.green);
                break;
            }
        }
	
    }
    
}
