using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterHeight : MonoBehaviour
{
    public Transform zeropoint;
    public Collider colobj;
    public bool trigerOn;
    public MeshRenderer waterRenderer;

    // Start is called before the first frame update
    void Start()
    {
        waterRenderer = gameObject.GetComponentInChildren<MeshRenderer>();
       
    }

    // Update is called once per frame
    void Update()
    {
        trigerOn = gameObject.GetComponentInChildren<SendCol>().returnTriggerOn();
        colobj = gameObject.GetComponentInChildren<SendCol>().returnHitobj();
        if (Mathf.Abs(transform.rotation.x) > 0.7f || Mathf.Abs(transform.rotation.z) > 0.7f)
        {
            waterRenderer.enabled = false;
            transform.position = zeropoint.position;
        }
        if (trigerOn && colobj.transform.tag == "potwater")
        {
            if (!waterRenderer.enabled)
            {
                waterRenderer.enabled = true;
            }
            if (waterRenderer.enabled && gameObject.transform.localPosition.z < 0.075f)
            {
                gameObject.transform.Translate(Vector3.up * Time.deltaTime *0.01f);
            }
        }
      
    }
  /*  private void OnTriggerEnter(Collider other)
    {
        colobj = other;
        trigerOn = true;
    }
    private void OnTriggerExit(Collider other)
    {
        colobj = null;
        trigerOn = false;
    }*/
}
