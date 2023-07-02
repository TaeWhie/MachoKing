using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raysibalamidigin : MonoBehaviour
{
    public GameObject m_Dot;
    //  public VRInputModule m_InputMoudle;
    RectTransform rectTransform;
    public float Defaultlength = 3.0f;
    private LineRenderer lineRenderer = null;
    GameObject StateUi;
    StateUI stateUi;
    bool UI=true;
    public Vector3 screenPos;
    GameObject inst;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        StateUi= Resources.Load("StateUi") as GameObject;
        stateUi=StateUi.GetComponent<StateUI>();
       // Debug.Log
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLine();

    }
    void UpdateLine()
    {
        float targetlength = Defaultlength;
        RaycastHit hit;
        hit= CreateRaycast(targetlength);
        //if (Physics.Raycast(transform.position, transform.forward, out hit, targetlength))
        //{
        //    if (hit.transform.GetComponent<State>())
        //    {
        //        rectTransform.anchoredPosition3D = hit.transform.position;
        //        if (UI)
        //        {
        //            UIState(hit);
        //            UI = false;
        //        }
        //    }
        //}
        Vector3 endPosition = transform.position + (transform.forward * targetlength);
        if (hit.collider != null)
        {
            if (hit.transform.GetComponent<State>())
            {
               // screenPos = Camera.main.WorldToViewportPoint(hit.transform.position);
                if (UI)
                {
                    UI = false;
                    UIState(hit);
                }
            }
            endPosition = hit.point;
        }
        else
        {
            if (inst != null)
            {
                Destroy(inst);
                UI = true;
            }
        }

        m_Dot.transform.position = endPosition;

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, endPosition);
    }
    void UIState(RaycastHit hit)
    {
        State state = hit.transform.GetComponent<State>();      
        inst=stateUi.ChangeUi(state, hit);
    }
    RaycastHit CreateRaycast(float length)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, length);
        return hit;
    }
}
