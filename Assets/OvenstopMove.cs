using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenstopMove : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Lock")
        {
            rb.isKinematic = true;
        }
    }
}
