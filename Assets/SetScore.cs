using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScore : MonoBehaviour
{
    public GameObject Mix;
   public GameObject Dough;
    public GameObject Score;
    public GameObject Clock;
    int count;
    // Start is called before the first frame update
    void Start()
    {   

    }

    // Update is called once per frame
    void Update()
    {
        if(!Dough)
        {
            Dough = GameObject.Find("dough(Clone)");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "dough(Clone)")
        {
            Debug.Log("3");
            MixScore();
            TimeScore();
            CookScore();
            IngrScore();
            Score.GetComponent<Score>().ScoreOn();
        }

        
    }
 
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "dough(Clone)")
            Score.GetComponent<Score>().ScoreOff();
    }
    void MixScore()
    {

        if (Dough.transform.GetChild(0).GetChild(3).gameObject.activeSelf)
        {
            Score.GetComponent<Score>().mixscore += 10;
        }
        if (Dough.transform.GetChild(0).GetChild(4).gameObject.activeSelf)
        {
            Score.GetComponent<Score>().mixscore += 20;
        }

    }
    void TimeScore()
    {
        float time;
        time= Clock.GetComponent<Clock>().totaltime;
        if (time >120)
        {
            Score.GetComponent<Score>().timescore = 40;
        }
        else
        {
            Score.GetComponent<Score>().timescore = 0.33f * time;
        }
    }
    void CookScore()
    {
        switch (Dough.GetComponent<BakeIngre>().degree)
        {
            case 1:
                Score.GetComponent<Score>().cookscore = 20;
                Debug.Log("4");
                break;
            case 2:
                Score.GetComponent<Score>().cookscore = 10;
                Debug.Log("5");
                break;
            case 3:
                Score.GetComponent<Score>().cookscore = 0;
                Debug.Log("6");
                break;
        }
       //
       // if (Dough.transform.GetChild(2).GetComponent<MeshRenderer>().material.color.r == 0.75f)
       // {
       //     Score.GetComponent<Score>().cookscore = 0;
       // }
       //else if (Dough.transform.GetChild(2).GetComponent<MeshRenderer>().material.color.r == 0.43f)
       // {
       //     Score.GetComponent<Score>().cookscore = 10;
       // }
       // else
       // {
       //     Score.GetComponent<Score>().cookscore = 20;
       // }
       // Debug.Log("2");
    }
    void IngrScore()
    {

        if (Dough.transform.GetChild(0).GetChild(5).gameObject.activeSelf)
        {
            if (Dough.transform.GetChild(0).GetChild(5).GetChild(0).gameObject.activeSelf)
            {
                Score.GetComponent<Score>().ingrscore += 5;
            }
            else if (Dough.transform.GetChild(0).GetChild(5).GetChild(1).gameObject.activeSelf)
            {
                Score.GetComponent<Score>().ingrscore += 10;
            }
        }
        count = Dough.transform.GetChild(1).childCount;
        switch (count)
        {
            case 8:
                Score.GetComponent<Score>().ingrscore += 10;
                break;
            case int count when count >= 6 && count <= 7:
                Score.GetComponent<Score>().ingrscore += 8;
                break;
            case int count when count >= 9 && count <= 10:
                Score.GetComponent<Score>().ingrscore += 8;
                break;
            case int count when count >= 11 && count <= 12:
                Score.GetComponent<Score>().ingrscore += 6;
                break;
            case int count when count >= 4 && count <= 5:
                Score.GetComponent<Score>().ingrscore += 6;
                break;
            case int count when count <= 4 && count >= 13:
                Score.GetComponent<Score>().ingrscore += 4;
                break;
        }
    }

}
