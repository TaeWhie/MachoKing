using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public Transform Source;
    public float distance=0.06f;
    private Vector3 RotAng;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log((Source.localRotation.eulerAngles-new Vector3(180, 180, 180))/180+Vector3.one);
        RotAng = (Source.localRotation.eulerAngles - new Vector3(180, 180, 180)) / 180+Vector3.one;
         transform.localPosition = new Vector3(RotAng.z * distance, gameObject.transform.localPosition.y, RotAng.x * distance);
         //   transform.localPosition = new Vector3(-Source.localRotation.x * distance, gameObject.transform.localPosition.y, -Source.localRotation.z * distance);
        
    }
}
