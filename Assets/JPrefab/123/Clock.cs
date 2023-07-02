using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;


public class Clock : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI text;
    public float time;
    public int minute;
    private bool end;
    public float totaltime;
    void Start()
    {
        text = transform.GetComponent<TextMeshProUGUI>();
        totaltime = time + (minute * 60);
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            totaltime -= Time.deltaTime;
        }
        if (time <= 0)
        {
            if (minute > 0)
            {
                minute -= 1;
                time = 60;
            }
            else
            {
                if (end)
                {
                    if (!GetComponent<AudioSource>().isPlaying)
                       SceneManager.LoadScene("BadSadEnd");
                }
                else
                {
                    if (!GetComponent<AudioSource>().isPlaying)
                        gameObject.GetComponent<AudioSource>().Play();
                    end = true;
                }
            }
        }
        if (time < 10 && minute < 10)
        {
            text.text = "0" + minute + ":0" + (int)time;
        }
        else if (time > 10 && minute < 10)
        {
            text.text = "0" + minute + ":" + (int)time;
        }
        else if (time < 10 && minute > 10)
        {
            text.text = minute + ":" + "0" + (int)time;
        }
        else if (time > 10 && minute > 10)
        {
            text.text = minute + ":" + (int)time;
        }



    }
}
