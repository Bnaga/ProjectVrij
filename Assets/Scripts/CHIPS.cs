using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CHIPS : MonoBehaviour {


	public fishDictionary[] dictionaries;
	public TextMeshPro display;
	private string displayText;
	private Coroutine processing;
	private int currentScreen = 0;
	private string[] intro = new string[] {	"LOADING C.H.I.P.S.","Computerized Hydrophonic\nImpression Procesing System","","",
											"Loading Language Module.........","Loading Network Module..........","Loading Microphone Module.......","",
											"[INITIALIZATION COMPLETE]","","......"};

	void Awake () {
		//reset known words
		foreach (fishDictionary dict in dictionaries){
				foreach (fishDictionary.word w in dict.dictionary){
					w.known = w.knownFromStart;
				}
			}
	}
	
	void Update () {
		display.text = displayText;
	}

	void updateScreen(){
		string text = "Known Words:\n";
		foreach (fishDictionary dict in dictionaries){
				foreach (fishDictionary.word w in dict.dictionary){
					if (w.known) {text+=w.meaning + "\n";}
					else{text+="????\n";}
				}
			}
			string[] lines = new string[]{text};
			processing = StartCoroutine(ScrollingText(lines));
	}

	public void NextScreen(){
		if (processing != null) return;
		switch (currentScreen){
			case 0:
				processing = StartCoroutine(ScrollingText(intro));
				currentScreen++;
				return;
			case 1:
				updateScreen();
				return;
			default:
				return;
		}
	}

	IEnumerator ScrollingText(string[] lines){    
		displayText =""; 
		bool pause = false;    
		 for (int j=0; j<lines.Length; j++){
            int i = 0;
            while( i < lines[j].Length ){
				char s = lines[j][i++];
                displayText += s;
				if (s=='.'){
					if (pause) yield return new WaitForSeconds(0.4f);
					pause = true;
				}else{ pause = false;}
                yield return new WaitForSeconds(0.02f);
            }
            yield return new WaitForSeconds(.5f);
			displayText += "\n";
        };
		processing=null;

	}
}
