using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonPressY : MonoBehaviour
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
        float distance = transform.position.y - startPos.y;

            if (Mathf.Abs(distance) >= pressLength)
            {
                transform.position = new Vector3( transform.position.x, startPos.y - pressLength, transform.position.z);
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
            if (transform.position.y > startPos.y)
            {
                transform.position = new Vector3(transform.position.x,startPos.y, transform.position.z);
            }
        }

}