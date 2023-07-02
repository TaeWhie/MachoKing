using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterfall : MonoBehaviour
{
    // public Transform mParticleSystem;
    private bool trigerOn = false;
    private Collider colobj;
    private MeshRenderer mMeshRenderer;
    public Transform bottom;
    // Start is called before the first frame update
    private void Awake()
    {
        mMeshRenderer = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
      /*   if (colobj)
         {
            UpdateStream(GetHeight(colobj));
         }*/
    }
    private void OnTriggerStay(Collider other)
    {
        colobj = other;
        UpdateStream(GetHeight(colobj));
        trigerOn = true;
    }

    private void OnTriggerExit (Collider other)
    {
        colobj = null;
        trigerOn = false;
        OutStream();
    }
    private float GetHeight(Collider collider)
    {
        return collider.transform.position.y + collider.bounds.size.y/2;
    }
    private void UpdateStream(float newHeight)
    {
        Vector3 newPosition = new Vector3(transform.position.x, newHeight, transform.position.z);

        newHeight =  Vector3.Distance(newPosition, bottom.position)/ Vector3.Distance(gameObject.transform.parent.position, bottom.position);

        mMeshRenderer.material.SetFloat("_Cutoff", newHeight);
    }
    private void OutStream()
    {
        mMeshRenderer.material.SetFloat("_Cutoff", 0);

    }
}
