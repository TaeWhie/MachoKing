using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sampleray : MonoBehaviour
{
    // Start is called before the first frame update
    RaycastHit hit;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward,Color.green,20f);
        if (Physics.Raycast(transform.position, transform.forward, out hit,20f))
        {
            //if(hit.transform.GetComponent<StickButton>())
            //{
            //    Debug.Log("1");
            //    hit.transform.GetComponent<StickButton>().Onclick();
            //}
            if(hit.transform.tag=="stick")
            {
                Debug.Log("2");
                hit.transform.GetComponent<StickButton>().Onclick();
            }
            if (hit.transform.GetComponent<BackSound>())
            {
                hit.transform.GetComponent<BackSound>().Onclick();
            }
        }
    }
}
