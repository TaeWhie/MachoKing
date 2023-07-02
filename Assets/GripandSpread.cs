using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GripandSpread : MonoBehaviour
{
    public GameObject SpreadParticle;
    bool spawn = false;
    // Update is called once per frame

    void Update()
    {
        if (gameObject.GetComponent<OVRGrabbable>().returngrab())
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
        if (!gameObject.GetComponent<OVRGrabbable>().returngrab() &&
            gameObject.transform.GetChild(1).gameObject.activeSelf == true && spawn == false)
        {
            GameObject Spreadobj= Instantiate(SpreadParticle,gameObject.transform.position, SpreadParticle.transform.rotation);
            Spreadobj.GetComponent<LiquidDrop>().Begin();
            spawn = true;
        }
        if(spawn==true)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            transform.localScale -= Vector3.one * 0.02f;
            if(transform.localScale.x<=0)
            {
                Destroy(gameObject);
            }
        }
    }

}
