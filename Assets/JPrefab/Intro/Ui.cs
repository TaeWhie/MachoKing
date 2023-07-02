using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Ui : MonoBehaviour
{
    public GameObject Intro;
    public GameObject Main;
    public GameObject[] Raycasts;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
      if(OVRInput.Get(OVRInput.Button.Any))
        {
            Intro.SetActive(false);
            Main.SetActive(true);
            TurnonRay();
        }
     
        /*else
        {
            Debug.Log("hi");
            GameObject.Find("Raycast").GetComponent<LineRenderer>().enabled = true;
            transform.rotation = new Quaternion(0.0f, 0f, 0f, 0f);
            GameObject.Find("Main Camera").GetComponent<Transform>().rotation= new Quaternion(0.0f, 0f, 0f, 0f);
        }*/
       
    }
    void TurnonRay()
    {
        for (int i = 0; i < Raycasts.Length; i++)
        {
            Raycasts[i].SetActive(true);
        }
    }
  
}
