using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasteGrab : MonoBehaviour
{
    private OVRGrabbable grab;
    // Start is called before the first frame update
    void Start()
    {
        grab = gameObject.GetComponent<OVRGrabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(grab.returngrab())
        {
            if (grab.grabbedBy.name == "RightHandAnchor")
            {
                if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0)
                {
                    if (OVRInput.GetDown(OVRInput.Button.One))
                    {
                        gameObject.GetComponent<PourDetector>().StartPour();
                    }
                    if (OVRInput.GetUp(OVRInput.Button.One))
                    {
                        gameObject.GetComponent<PourDetector>().EndPour();
                    }
                }
            }
            else if (grab.grabbedBy.name == "LeftHandAnchor")
            {
                if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0)
                {
                    if (OVRInput.GetDown(OVRInput.Button.Three))
                    {
                        gameObject.GetComponent<PourDetector>().StartPour();
                    }
                    if (OVRInput.GetUp(OVRInput.Button.Three))
                    {
                        gameObject.GetComponent<PourDetector>().EndPour();
                    }
                }
            }
        }
    }
}
