using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

    public bool change_on_load = false;
    public string scene_name;
	// Use this for initialization
	void Start () {
        //fader.GetComponent<Animator>().SetBool("Fade", true);
        if (change_on_load == true)
        {
            StartCoroutine(startGame());
        }
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator startGame()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(scene_name, LoadSceneMode.Single);
    }

    public void play()
    {
        SceneManager.LoadScene("info", LoadSceneMode.Single);
    }

    public void exit()
    {
        Application.Quit();
    }
}
