using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDrop : MonoBehaviour
{

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.GetComponent<Reposition>())
        {
            collision.gameObject.GetComponent<Reposition>().nowDrop = true;
        }
        else if (collision.gameObject.tag == "Food")
        {
            collision.gameObject.GetComponent<OVRGrabbable>().enabled = false;
            collision.transform.localScale -= Vector3.one * 0.02f;
            if (collision.transform.localScale.x <= 0)
            {
                Destroy(collision.gameObject);
            }
        }
    }

}
