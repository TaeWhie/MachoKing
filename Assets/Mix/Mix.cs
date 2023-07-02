using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mix : MonoBehaviour
{
    
    Vector3 OldPosition;
    public float Length;
    //  MeshRenderer meshRenderer;
    // public Material[] ChangeMaterial;
    // Start is called before the first frame update
    void Start()
    {
        Length = 0.0f;
      //  meshRenderer = transform.GetComponent<MeshRenderer>();
      //  meshRenderer.material = ChangeMaterial[0];

    }

    // Update is called once per frame
    void Update()
    {
        switch (Length)
        {
            case float Length when Length <= 3.0:
                transform.parent.GetComponent<PourDetector>().streamPrefab.GetComponent<LiquidDrop>().ActiveNum = 0;
                break;
            case float Length when Length >= 3.0f && Length <= 4.0f:
                //meshRenderer.material = ChangeMaterial[1];
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(3).gameObject.SetActive(true);
                transform.parent.GetComponent<PourDetector>().streamPrefab.GetComponent<LiquidDrop>().ActiveNum = 3;
                break;
            case float Length when Length >= 6.0f && Length <= 7.0f:
                // meshRenderer.material = ChangeMaterial[2];
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(3).gameObject.SetActive(false);
                transform.GetChild(4).gameObject.SetActive(true);
                transform.parent.GetComponent<PourDetector>().streamPrefab.GetComponent<LiquidDrop>().ActiveNum = 4;
                break;
        }
       

     
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(Length);
        OldPosition = other.transform.position;
    }
    private void OnTriggerStay(Collider other)
    {
         if (other.transform.tag==("Mix")&& 
        transform.GetChild(0).gameObject.activeSelf == true &&
        transform.GetChild(1).gameObject.activeSelf == true &&
        transform.GetChild(2).gameObject.activeSelf == true||transform.GetChild(3).gameObject.activeSelf==true)
        {
            if (other.gameObject.GetComponent<MixerOnOff>())
            {
               if(other.gameObject.GetComponent<MixerOnOff>().Onoff)
                {
                    Length += Time.deltaTime;
                    gameObject.transform.Rotate(0,1, 0);
                    if(!gameObject.GetComponent<AudioSource>().isPlaying)
                    gameObject.GetComponent<SoundPlayer>().playsound(0, true);
                }
               else
                {
                    if (gameObject.GetComponent<AudioSource>().isPlaying)
                        gameObject.GetComponent<AudioSource>().Pause();
                }
            }
            else
            {
                Debug.Log((other.transform.position - OldPosition).magnitude);
                Length += (other.transform.position - OldPosition).magnitude/250;
                gameObject.transform.Rotate(0, (other.transform.position - OldPosition).magnitude, 0);
                if (!gameObject.GetComponent<AudioSource>().isPlaying)
                gameObject.GetComponent<SoundPlayer>().playsound(0, true);
            }
           
        }
        OldPosition = other.transform.position;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == ("Mix"))
        {
            gameObject.GetComponent<AudioSource>().Pause();
        }
    }
}
