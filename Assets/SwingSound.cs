using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<Move>().ReturnVelocity().sqrMagnitude >= 10)
        {
            if(!gameObject.GetComponent<AudioSource>().isPlaying)
            gameObject.GetComponent<SoundPlayer>().playsound(3, false);
        }
    }
}
