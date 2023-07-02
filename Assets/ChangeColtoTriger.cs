using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColtoTriger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Source")
        {
            gameObject.GetComponent<SphereCollider>().isTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Source")
        {
            gameObject.GetComponent<SphereCollider>().isTrigger = false;
        }
    }
}
