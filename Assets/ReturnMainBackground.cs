using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnMainBackground : MonoBehaviour
{
    private bool saberSpawn = false;
    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("lightsaber1(Clone)")&&!saberSpawn)
        {
            if (gameObject.GetComponent<AudioSource>().clip == gameObject.GetComponent<SoundPlayer>().soundsource[0])
            {
                gameObject.GetComponent<SoundPlayer>().playsound(1, false);
                saberSpawn = true;
            }
        }
        else if (GameObject.Find("axe(Clone)") && !saberSpawn)
        {
            if (gameObject.GetComponent<AudioSource>().clip == gameObject.GetComponent<SoundPlayer>().soundsource[0])
            {
                gameObject.GetComponent<SoundPlayer>().playsound(2, false);
                saberSpawn = true;
            }
        }

        if (gameObject.GetComponent<AudioSource>().clip!=gameObject.GetComponent<SoundPlayer>().soundsource[0])
        {
            if(!gameObject.GetComponent<AudioSource>().isPlaying)
            {
                gameObject.GetComponent<SoundPlayer>().playsound(0, true);
            }
        }

    }
}
