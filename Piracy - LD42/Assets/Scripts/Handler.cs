using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Handler : MonoBehaviour {

    public Text rate;
    private float d_speed;
    public string p_download;
    private float total_speed;

    private void FixedUpdate()
    {
        d_speed = 0.001f * total_speed;
        p_download = download(d_speed);
        rate.text = p_download;
    }

    private string download(float val)
    {
        string space = "KB";
        val = val * 1000;
        //Debug.Log(val);
        if (val > 1)
        {
            space = "MB";
        }

        if (val > 10)
        {
            val = val / 10;
            space = "GB";
        }

        /*if (val > 1000)
        {
            val = val / 10000;
            space = "TB";
        }*/
        return val.ToString("F2") + space + "/S";
    }

    private void Start()
    {
        total_speed = 0;
        InvokeRepeating("moreDownload", 0f, 0.1f);
        GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().StopMusic();
        GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayMusic();
    }

    public void Lost()
    {
        PlayerPrefs.SetString("download", p_download);
        SceneManager.LoadScene("lost", LoadSceneMode.Single);
    }

    public void moreDownload()
    {
        total_speed = total_speed + 0.1f;
    }
}
