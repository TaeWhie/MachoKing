using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSet : MonoBehaviour
{
    private void Awake()
    {
        if(saves.stick)
        {
          transform.GetComponent<OVRPlayerController>().EnableLinearMovement = true;
          transform.GetComponent<OVRPlayerController>().EnableRotation = true;
        }
        else
        {
            transform.GetComponent<OVRPlayerController>().EnableLinearMovement = false;
            transform.GetComponent<OVRPlayerController>().EnableRotation = false;
        }
        if(saves.sound)
        {
            transform.GetComponent<AudioSource>().enabled = true;
        }
        else
        {
            transform.GetComponent<AudioSource>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
