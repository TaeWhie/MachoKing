using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    private bool push = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (push)
        { 
            if (!gameObject.GetComponent<AudioSource>().isPlaying)
            {
                SceneManager.LoadScene("Intro");
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="hand")
        {
           gameObject.GetComponent<AudioSource>().Play();
            push = true;
        }
    }
}
