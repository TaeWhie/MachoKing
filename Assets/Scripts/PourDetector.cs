using System.Collections;
using UnityEngine;

public class PourDetector : MonoBehaviour
{

    public int pourThreshold = 45;
    public Transform origin = null;
    public GameObject streamPrefab = null;

    private bool isPouring = false;
    private LiquidDrop currentStream = null;

    public bool ReturnPour()
    {
        return isPouring;
    }
    private void Update()
    {
        bool pourCheck = CalculatePourAngle() < pourThreshold;

        if(isPouring!=pourCheck)
        {
            isPouring = pourCheck;
            if(isPouring)
            {
                if(!gameObject.GetComponent<PasteGrab>())
                StartPour();
            }
            else
            {
                if(!gameObject.GetComponent<PasteGrab>())
                EndPour();
            }
        }
    }
    public void StartPour()
    {
        print("Start");
        currentStream = CreateStream();
        currentStream.Begin();
    }
    public void EndPour()
    {
        print("End");
        currentStream.end();
        currentStream = null;
        if(gameObject.GetComponent<MixBowl>())
        {
            for (int i = 0; i < transform.GetChild(0).childCount; i++)
            {
                transform.GetChild(0).GetChild(i).gameObject.SetActive(false);
                transform.GetChild(0).gameObject.GetComponent<Mix>().Length = 0;
            }
        }
    }
    private float CalculatePourAngle()
    {
        return transform.forward.y*Mathf.Rad2Deg;
    }
    private LiquidDrop CreateStream()
    {
        GameObject streamObject = Instantiate(streamPrefab, origin.position, Quaternion.identity, transform);
        return streamObject.GetComponent<LiquidDrop>();
    }
}