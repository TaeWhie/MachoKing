using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutChild : MonoBehaviour
{
    private void Update()
    {
        if(gameObject.GetComponent<OVRGrabbable>().returngrab())
        {
                transform.parent = null;
                transform.gameObject.GetComponent<MeshRenderer>().enabled = true;
              //  gameObject.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.tag = "Food";
        }
    }
}
