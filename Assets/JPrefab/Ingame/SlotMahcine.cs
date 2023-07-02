using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotMahcine : MonoBehaviour
{
    public GameObject[] SlotSkillObject;
    int ItemCnt = 3;
    public int[] answer = new int[3];
    public Sprite[] anotherSlot = new Sprite[4];
    public string Exclude;
    bool movement;
    float ii;
    public int num;
    void Start()
    {
        num = 0;
        EditSlot(Exclude);
        for (int i = 0; i < 3; i++)
        {
              answer[i] = Random.Range(0, 3);
              StartCoroutine(StartSlot(i));
        }
        ii = 0;
      
    }

    // Update is called once per frame
    void Update()
    {
        if(movement)
        {
            //vr기기 움직임멈춤
           
        }
        ii += Time.deltaTime;
        if (ii >= 5f)
        {
            transform.GetComponent<Canvas>().enabled = false;
        }
        
    }

    public void EditSlot(string text)
    {
        if(text == ("Cut"))
        {
            GameObject[] Cut = GameObject.FindGameObjectsWithTag("CutSlot");
            for(int i=0; i<Cut.Length; i++)
            {
                Cut[i].GetComponent<Image>().sprite = anotherSlot[i];
            }
        }
        else if(text == ("Mix"))
        {
            GameObject[] Mix = GameObject.FindGameObjectsWithTag("MixSlot");
            for (int i = 0; i < Mix.Length; i++)
            {
                Mix[i].GetComponent<Image>().sprite = anotherSlot[i];
            }
        }
        else if(text ==("Pan"))
        {
            GameObject[] Pan = GameObject.FindGameObjectsWithTag("PanSlot");
            for (int i = 0; i < Pan.Length; i++)
            {
                Pan[i].GetComponent<Image>().sprite = anotherSlot[i];
            }
        }
    }
  
    
    IEnumerator StartSlot(int SlotIndex)
    {
        movement = true;
        for(int i=0; i< (ItemCnt* (6+SlotIndex*4)+answer[SlotIndex])*4; i++)
        {
            SlotSkillObject[SlotIndex].transform.localPosition -= new Vector3(0, 50f, 0);
            if(SlotSkillObject[SlotIndex].transform.localPosition.y<50f)
            {
                SlotSkillObject[SlotIndex].transform.localPosition += new Vector3(0, 300f, 0);
            }
            yield return null;
        }
        movement = false;
        num += 1;
    }
}
