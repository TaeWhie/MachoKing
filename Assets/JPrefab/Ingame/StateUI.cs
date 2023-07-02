using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateUI : MonoBehaviour
{
    State state;
    Image image;
    Text Name;
    Text amount;
    Transform[] stateUi=new Transform[6];
    GameObject Cam;
  public  GameObject StateUi;
    void Start()
    {
        Cam = GameObject.Find("Control");
        StateUi = Resources.Load("StateUi") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Cam.transform);
    }
    public GameObject ChangeUi(State state, RaycastHit hit)
    {
        stateUi[0] = transform.GetChild(0);//배경
        stateUi[1] = transform.GetChild(1);//이름
        stateUi[2] = transform.GetChild(2);//굽기정도
        stateUi[3] = transform.GetChild(3);//양
        stateUi[4] = transform.GetChild(4);
        //for(int i=0; i< transform.childCount; i++)
        //{
        //}
        //for (int i = 0; i < stateUi.Length; i++)
        //{
        //    if (stateUi[i])
        //    {
        //        Name = stateUi[i].GetComponent<Text>();
        //    }
        //    if (stateUi[i].name == "Amount")
        //    {
        //        amount = stateUi[i].GetComponent<Text>();
        //    }
        //}
        Name = stateUi[1].GetComponent<Text>();
        amount = stateUi[3].GetComponent<Text>();
        int Amount = state.amount;
        Name.text = state.Name;
        amount.text = Amount.ToString();
       GameObject inst= Instantiate(StateUi, hit.transform.position + (new Vector3(0, 0.5f, 0)), hit.transform.rotation);

        return inst;
    }
}
