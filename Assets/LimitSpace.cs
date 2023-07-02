using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitSpace : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Reposition>())
        {
            other.gameObject.GetComponent<Reposition>().nowDrop = true;
        }
        else if (other.gameObject.tag == "Food")
        {
            other.gameObject.GetComponent<OVRGrabbable>().enabled = false;
                Destroy(other.gameObject);
        }
    }
}
