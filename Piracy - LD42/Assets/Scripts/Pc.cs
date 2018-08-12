using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pc : MonoBehaviour {

    public float reserved_space = 50f;
    public float total_space = 128;
    public float download_rate;
    public TextMesh info;
    public GameObject bar;
    public Sprite red;
    public Sprite blue;
    private int total_speed;

    private void FixedUpdate()
    {
        total_space = (ScanForItems(gameObject.GetComponent<SphereCollider>()) * 64) + 64;
        float percentage = getPercentage();
        bar.transform.localScale = new Vector3(percentage, 1, 1);
        if (percentage > 0.7f)
        {
            bar.GetComponent<SpriteRenderer>().sprite = red;
        } else
        {
            bar.GetComponent<SpriteRenderer>().sprite = blue;
        }
        if (reserved_space < total_space)
        {
            reserved_space = reserved_space + download_rate;
        } else if (reserved_space >= total_space)
        {
            reserved_space = total_space;
            Lose();
        }
        download_rate = 0.001f * total_speed;
        info.text = convert(freeSpace()) + " Free from " + convert(total_space);
    }

    private int ScanForItems(SphereCollider item)
    {
        Vector3 center = item.transform.position + item.center;
        float radius = item.radius;
        int count = 0;

        Collider[] allOverlappingColliders = Physics.OverlapSphere(center, radius);
        foreach(Collider overlap in allOverlappingColliders)
        {
            if (overlap.gameObject.tag == "ssd")
            {
                count++;
            }
        }

        return count;
    }

    private float getPercentage()
    {
        return (reserved_space / total_space * 100) / 100;
    }

    private float freeSpace()
    {
        return total_space - reserved_space;
    }

    private string convert(float val)
    {
        string space = "GB";
        if (val > 1000)
        {
            val = val / 100;
            space = "TB";
        }
        return val.ToString("F2") + space;
    }

    private void Lose()
    {
        //Debug.Log("Lost!");
        GameObject.FindGameObjectWithTag("handler").GetComponent<Handler>().Lost();
        //Time.timeScale = 0;
    }

    private void Start()
    {
        total_speed = 0;
        InvokeRepeating("moreDownload", 0f, 1f);
    }

    public void moreDownload()
    {
        total_speed++;
    }
}
