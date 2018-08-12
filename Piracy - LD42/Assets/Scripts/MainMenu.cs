using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    private void Start()
    {
        PlayerPrefs.SetString("download", "0");
        GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().StopMusic();
        GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayMusic();
    }

    // Update is called once per frame
    void Update () {
        Screen.lockCursor = false;
    }
}
