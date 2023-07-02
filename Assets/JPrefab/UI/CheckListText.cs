using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckListText : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI text;
    public GameObject tomatoetc;
    LiquidDrop liquid;
    public GameObject Bowl;
    CanvasGroup Cg;
    bool on;
    bool off;
    PourDetector pourDetector;
    powderPour powderPour;
    public int num;
    public bool Crash;
    void Start()
    {
        on = true;
        off = true;
     if(tomatoetc.GetComponent<PourDetector>())
        {
            liquid = tomatoetc.GetComponent<PourDetector>().streamPrefab.GetComponent<LiquidDrop>();
            pourDetector = tomatoetc.GetComponent<PourDetector>();
        }
     else if(tomatoetc.GetComponent<powderPour>())
        {
            liquid = tomatoetc.GetComponent<powderPour>().PowderPrefab.GetComponent<LiquidDrop>();
            powderPour = tomatoetc.GetComponent<powderPour>();
        }
        text = transform.GetComponent<TextMeshProUGUI>();
        Cg = transform.parent.GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Bowl.transform.GetChild(0).GetChild(num).gameObject.activeSelf)
        {
            if (on && off)
            {
                NameCheck();
                StartCoroutine(Create());
            }

        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
            text.fontStyle = FontStyles.Normal;
            on = true;
          //  Cg.alpha = 0;
          //   StartCoroutine(Create()); 
        }
    }
    void NameCheck()
    {
        Debug.Log("fucon");
        on = false;
      //  transform.parent.GetComponent<Canvas>().enabled = true;
        transform.GetChild(0).gameObject.SetActive(true);
        text.fontStyle = FontStyles.Strikethrough;
    }

  /*  public  IEnumerator Set()
    {    
        yield return new WaitForSeconds(2.5f);
        transform.parent.GetComponent<Canvas>().enabled = false;
        onoff = false;
    }*/
     public  IEnumerator Create()
    {
        Debug.Log("coron");
        off = false;
        while (Cg.alpha<1)
        {
            Cg.alpha += 0.1f;
            yield return new WaitForSeconds(0.2f);
        }
        StartCoroutine(Missing());
    }
    IEnumerator Missing()
    {
        while (Cg.alpha > 0)
        {
             Cg.alpha -= 0.1f;
            yield return new WaitForSeconds(0.2f);
        }
        off = true;
    }
}

