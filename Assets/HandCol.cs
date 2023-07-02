using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCol : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "hand")
        {
            other.GetComponent<SphereCollider>().isTrigger = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "hand")
        {
            collision.gameObject.GetComponent<SphereCollider>().isTrigger = true;
        }
    }
}
