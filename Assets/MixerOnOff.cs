using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixerOnOff : MonoBehaviour
{
    private OVRGrabbable grab;
    public bool Onoff;
    // Start is called before the first frame update
    void Start()
    {
        grab = gameObject.GetComponent<OVRGrabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grab.returngrab())
        {
            if (grab.grabbedBy.name == "RightHandAnchor")
            {
                if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0)
                {
                    if (OVRInput.GetDown(OVRInput.Button.One))
                    {
                        Onoff = true;
                        gameObject.GetComponent<SoundPlayer>().playsound(1, true);
                    }
                    if (OVRInput.GetUp(OVRInput.Button.One))
                    {
                        Onoff = false;
                        gameObject.GetComponent<AudioSource>().Pause();
                    }
                }
            }
            else if (grab.grabbedBy.name == "LeftHandAnchor")
            {
             if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0)
                    {
                        if (OVRInput.GetDown(OVRInput.Button.Three))
                        {
                            Onoff = true;
                            gameObject.GetComponent<SoundPlayer>().playsound(1, true);
                        }
                        if (OVRInput.GetUp(OVRInput.Button.Three))
                        {
                            Onoff = false;
                             gameObject.GetComponent<AudioSource>().Pause();
                        }
                    }
              }
        }
    }
}

