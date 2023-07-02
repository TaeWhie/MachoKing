using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raysibal : MonoBehaviour
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
    }
    void UpdateLine()
    {

        float targetlength = Defaultlength;

        RaycastHit hit = CreateRaycast(targetlength);
        Vector3 endPosition = transform.position + (transform.forward * targetlength);
        if (hit.collider != null)
        {
            endPosition = hit.point;
         
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
