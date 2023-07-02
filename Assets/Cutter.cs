using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutter : MonoBehaviour
{
    // Start is called before the first frame update
  
    public bool IsSharp;
    void Start()
    {
               
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
         if (collision.gameObject.tag=="Food")
        {
            gameObject.tag = "Waittag";
            StartCoroutine(waitsec());
        }
         else
        {
            if (!gameObject.GetComponent<AudioSource>().isPlaying)
            {
                gameObject.GetComponent<SoundPlayer>().playsound(2, false);
            }
        }

    }

    public bool ReturnIsSharp()
    {
        return IsSharp;
    }
    IEnumerator waitsec()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.tag = "Cutter";

    }
}
