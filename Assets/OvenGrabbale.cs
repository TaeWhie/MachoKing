using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenGrabbale : OVRGrabbable
{
    public Transform handler;
    public Rigidbody ovenrb;
    private bool nowGrab=false;
    // Start is called before the first frame update
    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);
        nowGrab = true;
        ovenrb.isKinematic = false;
    }
    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);
        transform.position = handler.transform.position;
        transform.rotation = handler.transform.rotation;

        gameObject.GetComponent<Rigidbody>().isKinematic = true;

        Rigidbody rbhandler = handler.GetComponent<Rigidbody>();
        rbhandler.velocity = Vector3.zero;
        rbhandler.angularVelocity = Vector3.zero;

        nowGrab = false;
    }
    private void Update()
    {
        if(Vector3.Distance(handler.position,transform.position)>0.4f)
        {
            grabbedBy.ForceRelease(this);
        }
    }
    public bool returnNowGrab()
    {
        return nowGrab;
    }
}
