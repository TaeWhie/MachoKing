using UnityEngine;
using Valve.VR.InteractionSystem;

public class ButtonEvents : MonoBehaviour
{
    public Rigidbody doorRB;
    public GameObject sinkWater;
    public void OnPress(Hand hand)
    {
        Debug.Log("SteamVR Button pressed!");
    }

    public void OnCustomButtonPress()
    {
        Debug.Log("We pushed our custom button!");
        if(doorRB.isKinematic==true)
        {
            doorRB.isKinematic = false;
            doorRB.AddForce(new Vector3(5, 0, 0));
        }
    }
    public void SinkButtonPress()
    {
        Debug.Log("We pushed Sink button!");
        if(sinkWater.activeSelf==true)
        {
            sinkWater.SetActive(false);
        }
        else
        {
            sinkWater.SetActive(true);
        }
    }
}