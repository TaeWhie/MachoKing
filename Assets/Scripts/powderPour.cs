using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powderPour : MonoBehaviour
{
    public int pourThreshold = 45;
    public Transform origin = null;
    public GameObject PowderPrefab = null;

    private bool isPouring = false;
    private LiquidDrop currentStream = null;
    private void Update()
    {
        bool pourCheck = CalculatePourAngle() < pourThreshold;
        if (isPouring != pourCheck)
        {
            isPouring = pourCheck;
            if (isPouring)
            {
                StartPour();
            }
            else
            {
                EndPour();
            }
        }
    }
    private void StartPour()
    {
        print("Start");
        currentStream = CreateStream();
        currentStream.Begin();
    }
    private void EndPour()
    {
        print("End");

    }
    private float CalculatePourAngle()
    {
        return transform.forward.y * Mathf.Rad2Deg;
    }
        private LiquidDrop CreateStream()
    {
        GameObject streamObject = Instantiate(PowderPrefab, origin.transform.position, PowderPrefab.transform.rotation);
        return streamObject.GetComponent<LiquidDrop>();
    }
}
