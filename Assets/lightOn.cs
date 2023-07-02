using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightOn : MonoBehaviour
{
    public IsLock nowlock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(nowlock.returnisLock())
        {
            gameObject.GetComponent<Light>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Light>().enabled = false;
        }
    }
}
