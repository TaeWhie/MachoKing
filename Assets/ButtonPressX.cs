using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonPressX : MonoBehaviour
{
    [System.Serializable]
    public class ButtonEvent : UnityEvent { }

    public float pressLength;
    public bool pressed;
    public ButtonEvent downEvent;

    Vector3 startPos;
    Rigidbody rb;

    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float distance = transform.position.x - startPos.x;

        if (distance<0)
        { 
         if (Mathf.Abs(distance) >= pressLength)
             {
                 transform.position = new Vector3(startPos.x - pressLength, transform.position.y, transform.position.z);
                 if (!pressed)
                 {
                     pressed = true;
                     downEvent?.Invoke();
                 }
             }
             else
             {
                 pressed = false;
             }
         if (transform.position.x > startPos.x)
         {
             transform.position = new Vector3(startPos.x, transform.position.y,transform.position.z);
         }
        }
        else
        {
            transform.position = startPos;
        }
    }
}