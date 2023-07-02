using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WhatMix : MonoBehaviour
{
    ArrayList MixList = new ArrayList();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Addmix(string mixname, int amount)
    {
        MixList.Add(mixname);
    }
    private void OnCollisionEnter(Collision collision)
    {
        int amount=0;
        Addmix(collision.transform.name, amount);
    }
}
