using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngreGrabbable : OVRGrabbable
{
    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        if (transform.parent != null)
            transform.parent = transform.parent.parent;
    }
    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }
}
