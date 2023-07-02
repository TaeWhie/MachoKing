using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakeSound : MonoBehaviour
{
    public IsLock Lock;
    private bool one=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Lock==true&&one==false)
        {
            GetComponent<SoundPlayer>().playsound(0,true);
            one = true;
        }
        if(Lock==false)
        {
            one = false;
        }
    }
}
