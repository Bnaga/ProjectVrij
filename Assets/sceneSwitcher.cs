using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class sceneSwitcher : MonoBehaviour {
	public string[] scenes;

	void Update () {
		for (int i = 0;i<scenes.Length;i++){
			if (Input.GetKeyDown(i.ToString())) StartCoroutine(loadScene(scenes[i]));
		}
	}

	public static IEnumerator loadScene(string scene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
