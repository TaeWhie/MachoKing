using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Move : MonoBehaviour
{
    Vector3 oldPosition;
    Vector3 currentPosition;
    Vector3 velocity;
    Vector3 CrossVector;
    float speed;
    private Rigidbody rig;
    void Start()
    {
        oldPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.position;
        var distance = (currentPosition - oldPosition);
        velocity = distance / Time.deltaTime;
    
        CrossVector = Vector3.Cross(oldPosition, currentPosition).normalized;


      oldPosition = currentPosition;

    }
    public Vector3 ReturnCross()
    {
        return CrossVector;
    }
    public Vector3 ReturnVelocity()
    {
        return velocity;
    }
}
