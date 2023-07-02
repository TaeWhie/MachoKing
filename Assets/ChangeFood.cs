using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFood : MonoBehaviour
{
    public IsLock Lock;
    public float Baketime;

    // Start is called before the first frame update
    private void Update()
    {
        if (Lock.returnisLock() == true )
        {
            Baketime += Time.deltaTime;
            if(!gameObject.GetComponent<AudioSource>().isPlaying)
            gameObject.GetComponent<AudioSource>().Play();
        }
        else
        {
            Baketime = 0;
            gameObject.GetComponent<AudioSource>().Pause();
        }

    }
}
