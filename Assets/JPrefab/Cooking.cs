using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking : MonoBehaviour
{
    // Start is called before the first frame update
    Material[] Materials;
    public Material[] ChangeMaterial;
    Material Mat;
    float time;
    bool CollisionStay=false;
    MeshRenderer meshRenderer;
    Pan pan;
    void Start()
    { 
        meshRenderer=transform.GetComponent<MeshRenderer>();
        meshRenderer.material = ChangeMaterial[0];
        pan = GameObject.FindWithTag("Pan").GetComponent<Pan>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CollisionStay)
        {
            Debug.Log(time);
            if (pan.Heat)
            {
                time += Time.deltaTime;
                switch (time)
                {
                    case float time when time >= 4.0f && time <= 5.0f:
                        meshRenderer.material = ChangeMaterial[1];
                        break;
                    case float time when time >= 8.0f && time <= 9.0f:
                        meshRenderer.material = ChangeMaterial[2];
                        break;
                    case float time when time >= 12.0f && time <= 13.0f:
                        meshRenderer.material = ChangeMaterial[3];
                        break;
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
       if(collision.transform.tag == ("Pan"))
        {
            CollisionStay = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == ("Pan"))
        {
            CollisionStay = false;
        }
    }
}
