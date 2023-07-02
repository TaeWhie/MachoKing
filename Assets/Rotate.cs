using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float RotSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0,RotSpeed * Time.deltaTime, 0);

        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -RotSpeed * Time.deltaTime, 0);

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, RotSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, -RotSpeed * Time.deltaTime);

        }
    }
}
