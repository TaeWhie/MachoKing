using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{

    public float timescore;
    public int cutscore;
    public int mixscore;
    public int totalscore;
    public int cookscore;
    public int ingrscore;

    public TextMeshProUGUI[] text = new TextMeshProUGUI[5];

    public GameObject[] Star = new GameObject[5];
    Canvas canvas;
    void Start()
    {     
        for (int i = 0; i < 5; i++)
        {
            Star[i] = transform.GetChild(0).GetChild(2).GetChild(i).gameObject;
        }
        for(int i = 0; i<5 ; i++)
        {
            text[i] = transform.GetChild(0).GetChild(1).GetChild(6).GetChild(i).GetComponent<TextMeshProUGUI>();
        }
        canvas = transform.GetChild(0).GetComponent<Canvas>();
        //StartCoroutine(TimeOn());
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    public void ScoreOff()
    {
        canvas.enabled = false;
        for (int i = 0; i < 5; i++)
        {
            Star[i].SetActive(false);
        }
        timescore = 0;
        cutscore = 0;
        mixscore = 0;
        cookscore = 0;
        ingrscore = 0;
    }
    public void ScoreOn()
    {
        Debug.Log("3");
        StartCoroutine(TimeOn());
        canvas.enabled = true;
    }
    IEnumerator CreateStar()
    { 
        float[] time = new float[5];
        for (int i = 0; i < 5; i++)
        {
            if (totalscore >= (i+1) * 20)
            {
                Star[i].SetActive(true);
                time[i] = 0f;
                while (time[i] < 1f)
                {
                    Star[i].transform.localScale = Vector3.one * (1 + (time[i]));
                    time[i] += Time.deltaTime * 10;
                    yield return new WaitForSeconds(0.0005f);
                }
                Star[i].transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
        yield return null;
        
    }

    IEnumerator TimeOn()
    {
       int add=0;
        
       while(Math.Truncate(timescore) > add)
        {           
            add += 1;
            text[0].text = add.ToString();
            yield return new WaitForSeconds(0.01f);
       }
        StartCoroutine(IngrOn());
    }
    IEnumerator IngrOn()
    {
        int add = 0;
        while (ingrscore > add)
        {
            add += 1;
            text[1].text = add.ToString();
            yield return new WaitForSeconds(0.01f);
        }
       
        StartCoroutine(MixOn());
    }
    IEnumerator MixOn()
    {
        int add = 0;
        while (mixscore > add)
        {
            add += 1;
            text[2].text = add.ToString();
            yield return new WaitForSeconds(0.01f);
        }
        //StartCoroutine(TotalOn());
        StartCoroutine(CookOn());
    }
    IEnumerator CookOn()
    {
        int add = 0;
        while (cookscore > add)
        {
            add += 1;
            text[3].text = add.ToString();
            yield return new WaitForSeconds(0.01f);
        }
        StartCoroutine(TotalOn());
    }
  
    IEnumerator TotalOn()
    {
        int add = 0;
        add = (int)timescore + mixscore+cookscore+ingrscore;
        totalscore = add;
        text[4].text = add.ToString();
        StartCoroutine(CreateStar());
        yield return null;
    }
}
