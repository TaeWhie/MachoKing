using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixBowl : MonoBehaviour
{
    private PourDetector pourdetect;
    // Start is called before the first frame update
    void Start()
    {
        pourdetect = gameObject.GetComponent<PourDetector>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.GetChild(0).GetChild(0).gameObject.activeSelf)
        {
            pourdetect.streamPrefab.GetComponent<LiquidDrop>().ActiveNum = 0;
            pourdetect.enabled = true;

        }
        else if(gameObject.transform.GetChild(0).GetChild(3).gameObject.activeSelf)
        {
            pourdetect.streamPrefab.GetComponent<LiquidDrop>().ActiveNum = 3;
            pourdetect.enabled = true;
        }
        else if(gameObject.transform.GetChild(0).GetChild(4).gameObject.activeSelf)
        {
            pourdetect.streamPrefab.GetComponent<LiquidDrop>().ActiveNum = 4;
            pourdetect.enabled = true;
        }
        else
        {
            pourdetect.enabled = false;
        }
    }
}
