using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    // Start is called before the first frame update
    RaycastHit hit;
    public GameObject m_Dot;
  //  public VRInputModule m_InputMoudle;
    
    public float Defaultlength = 3.0f;
    private LineRenderer lineRenderer = null;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        UpdateLine();
        //if (Physics.Raycast(transform.position, transform.forward, out hit, 3f))
        //{
        //    if (hit.transform.GetComponent<Recipe>())
        //    {
        //        if (Input.GetKeyDown(KeyCode.Mouse0))
        //        {
        //            hit.transform.GetComponent<Recipe>().OnClick(hit);
        //        }
        //    }
        //}
    }
    public void UpdateLine()
    {      
        float targetlength = Defaultlength;
        RaycastHit hit = CreateRaycast(targetlength);
        Vector3 endPosition = transform.position + (transform.forward * targetlength);
        if (hit.collider != null)
        {
            endPosition = hit.point;
            
                if (gameObject.transform.parent.name == "RightHandAnchor")
                {
                    if (OVRInput.GetDown(OVRInput.Button.One))
                    {
                    if (hit.transform.GetComponent<Recipe>())
                    {
                        hit.transform.GetComponent<Recipe>().OnClick();
                    }

                    if (hit.transform.GetComponent<BackSound>())
                    {
                        hit.transform.GetComponent<BackSound>().Onclick();
                    }

                    if (hit.transform.GetComponent<StickButton>())
                    {
                        hit.transform.GetComponent<StickButton>().Onclick();
                    }
                }
                }
                else if (gameObject.transform.parent.name == "LeftHandAnchor")
                {
                if (OVRInput.GetDown(OVRInput.Button.Three))
                {
                    if (hit.transform.GetComponent<Recipe>())
                    {
                        hit.transform.GetComponent<Recipe>().OnClick();
                    }

                    if (hit.transform.GetComponent<BackSound>())
                    {
                        hit.transform.GetComponent<BackSound>().Onclick();
                    }

                    if (hit.transform.GetComponent<StickButton>())
                    {
                        hit.transform.GetComponent<StickButton>().Onclick();
                    }
                }     
            }

        }
        m_Dot.transform.position = endPosition;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, endPosition);
 
    }
    RaycastHit CreateRaycast(float length)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, length);
        return hit;
    }
}
