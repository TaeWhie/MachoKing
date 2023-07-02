using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoChild : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Plate" || collision.gameObject.tag == "Source"&& !gameObject.GetComponent<OVRGrabbable>().returngrab()&&!collision.gameObject.GetComponent<MixBowl>())
        {
            gameObject.transform.parent = collision.transform.GetChild(1).transform;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
