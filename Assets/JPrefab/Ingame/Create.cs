using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Create : MonoBehaviour
{
    public GameObject[] SpawnPoint; 
    GameObject[] knifePrefab=new GameObject[3];
    GameObject[] burnPrefab = new GameObject[3];
    GameObject[] mixPrefab = new GameObject[3];
    SlotMahcine slotmachine;
    bool create=false;
    // Start is called before the first frame update
    void Start()
    {
        create = false;
        slotmachine = GameObject.FindWithTag("SlotMachine").GetComponent<SlotMahcine>();
        //for(int i=0; i<9; i++)
        //  {
        //  Prefab[i]=
        // }
        knifePrefab[1] = Resources.Load("Cookingutensils/axe") as GameObject;
        knifePrefab[0] = Resources.Load("Cookingutensils/knife") as GameObject;
        knifePrefab[2] = Resources.Load("Cookingutensils/lightsaber1") as GameObject;
        mixPrefab[2] = Resources.Load("Cookingutensils/handblender") as GameObject;
        mixPrefab[0] = Resources.Load("Cookingutensils/Whisk") as GameObject;
        mixPrefab[1] = Resources.Load("Cookingutensils/woodspoon") as GameObject;
        burnPrefab[0] = Resources.Load("Cookingutensils/shield") as GameObject;
        burnPrefab[1] = Resources.Load("Cookingutensils/pan") as GameObject;
        burnPrefab[2] = Resources.Load("Cookingutensils/iron") as GameObject;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(slotmachine.num==3&&create==false)
        {
            int size = SpawnPoint.Length;
            switch (size)
            {
                case 1:
                    CreateTool(knifePrefab, 0);
                    break;
                case 2:
                    CreateTool(knifePrefab, 0);
                    CreateTool(mixPrefab, 1);
                    break;
                case 3:
                    CreateTool(knifePrefab, 0);
                    CreateTool(mixPrefab, 1);
                    CreateTool(burnPrefab, 2);
                    break;

            }
            create = true;
        }
    }
    void CreateTool(GameObject[] Prefabs,int num)
    {
        Instantiate(Prefabs[slotmachine.answer[num]], SpawnPoint[num].transform.position, Prefabs[slotmachine.answer[num]].transform.rotation);
       /* Instantiate(knifePrefab[slotmachine.answer[0]], SpawnPoint[0].transform.position, SpawnPoint[0].transform.rotation);
        Instantiate(mixPrefab[slotmachine.answer[1]], SpawnPoint[1].transform.position, SpawnPoint[1].transform.rotation);
        Instantiate(burnPrefab[slotmachine.answer[2]], SpawnPoint[2].transform.position, SpawnPoint[2].transform.rotation);*/

    }

}
