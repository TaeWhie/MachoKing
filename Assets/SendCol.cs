using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendCol : MonoBehaviour
{
    private Collider colobj;
    private bool trigerOn;
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
        colobj = other;
        trigerOn = true;
    }
    private void OnTriggerExit(Collider other)
    {
        colobj = null;
        trigerOn = false;
    }
   public Collider returnHitobj()
    {
        return colobj;
    }
    public bool returnTriggerOn()
    {
        return trigerOn;
    }
}
