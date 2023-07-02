using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapsound : MonoBehaviour
{
    private OVRGrabber hand;
    private bool Onetime = false;
    // Start is called before the first frame update
    void Start()
    {
        hand = gameObject.GetComponent<OVRGrabber>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hand.returngrab()&&Onetime==false)
        {
            gameObject.GetComponent<SoundPlayer>().playsound(0, false);
            Onetime = true;
        }
        if(!hand.returngrab())
        {
            Onetime = false;
        }
    }
}
