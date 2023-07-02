using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refill : MonoBehaviour
{
    public GameObject particle;
    public GameObject Refillobj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameObject.Find("1dough(Clone)")&& !GameObject.Find("2dough(Clone)") && !GameObject.Find("dough(Clone)"))
        {
            Instantiate(particle, gameObject.transform.position, particle.transform.rotation);
            Instantiate(Refillobj,gameObject.transform.position,Refillobj.transform.rotation);
        }
    }
}
