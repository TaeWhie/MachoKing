using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsLock : MonoBehaviour
{
    public bool nowLock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    { 
        if(other.tag=="Oven")
            nowLock = true;
        gameObject.GetComponent<SoundPlayer>().playsound(1, false);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Oven")
            gameObject.GetComponent<SoundPlayer>().playsound(0, false);
        nowLock = false;   
     }
    public bool returnisLock()
    {
        return nowLock;
    }
}
