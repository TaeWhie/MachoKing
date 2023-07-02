using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPosition : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bowl;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = bowl.transform.position + new Vector3(0f, 0.3f, 0f);
    }
}
