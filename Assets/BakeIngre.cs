using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakeIngre : MonoBehaviour
{
    public float heattime;
    public float bakeouttime=0;
    public int degree;
    // Start is called before the first frame update
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        switch (heattime)
        {
            case float heattime when heattime >= 5.0f && heattime <= 6.0f:
                if (gameObject.name == "SpreadCheese")
                {
                    transform.GetChild(0).gameObject.SetActive(false);
                }
                else
                {
                    transform.GetComponent<MeshRenderer>().enabled = false;
                }
                transform.GetChild(transform.childCount-1).gameObject.SetActive(true);
                transform.GetChild(transform.childCount - 1).GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1);
                degree = 1;
                break;
            case float heattime when heattime >= 8.0f && heattime <= 9.0f:
                    transform.GetChild(transform.childCount - 1).GetComponent<MeshRenderer>().material.color = new Color(0.75f, 0.63f, 0.53f);
                degree = 2;
                break;
            case float heattime when heattime >= 12.0 && heattime <= 13.0f:
                transform.GetChild(transform.childCount - 1).GetComponent<MeshRenderer>().material.color = new Color(0.43f, 0.42f, 0.39f);
                degree = 3;
                break;
        }


    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "OvenBake")
        {
            if (bakeouttime == 0)
                heattime = other.gameObject.GetComponent<ChangeFood>().Baketime;
            else
                heattime = bakeouttime + other.gameObject.GetComponent<ChangeFood>().Baketime;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag=="OvenBake")
        {
            bakeouttime = heattime;
        }
    }
}
