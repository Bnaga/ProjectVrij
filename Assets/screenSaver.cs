using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class screenSaver : MonoBehaviour {

    public string[] scenes;
    public float timePerScene = 8;
    public Image progressBar;
    private float timer = 0;
    private int currentScene = 0;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        progressBar.fillAmount = timer / timePerScene;
        if (timer > timePerScene)
        {
            int i = 0;
            foreach (string s in scenes)
            {
                i++;
                if (s == SceneManager.GetActiveScene().name) break;
            }
            string scene = scenes[i % scenes.Length];
            StartCoroutine(sceneSwitcher.loadScene(scene));
            timer = -Mathf.Infinity;
        }
	}
}
