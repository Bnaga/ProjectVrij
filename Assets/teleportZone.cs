using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

public class teleportZone : MonoBehaviour {
	public string teleportScene;
	private bool stopTransition = false;
	private bool stop2 = false;

	void OnTriggerEnter(Collider other){
		if (other.tag == "MainCamera"){
			stop2 = true;
			StartCoroutine(sceneTransition());
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "MainCamera"){
			stopTransition = true;
		}
	}

	IEnumerator sceneTransition(){
		int i = overlayImage.currentAlpha;
		while(i<270){
			i+=4;
			overlayImage.setAlpha(i);
			yield return null;
			if (stopTransition) break;
		}
		stop2=false;
		if (!stopTransition){
			overlayImage.setAlpha(0);
			changeScene(teleportScene);
		} else{
			stopTransition = false;
			while (i>0){
				i-=8;
				overlayImage.setAlpha(i);
				yield return null;
				if (stop2) break;
			}
		}
		
	}

	public static void changeScene(string name){
		SceneManager.LoadScene(name);
	}
}
