using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    public bool nowDrop=false;
    public string Reposname;
    public GameObject particle;
    private Transform Repos;
    // Start is called before the first frame update
    void Start()
    {
         Repos = GameObject.Find(Reposname).transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(nowDrop)
        {
            if (gameObject.tag == "Source")
            {
                if (!gameObject.GetComponent<MixBowl>())
                {
                    /*  transform.GetChild(0).GetChild(5).GetChild(transform.GetChild(0).GetChild(5).childCount - 1).gameObject.SetActive(false);
                      transform.GetChild(0).GetChild(5).GetChild(0).gameObject.SetActive(true);
                      for (int i = 0; i < transform.GetChild(1).childCount; i++)
                      {
                          Destroy(transform.GetChild(1).GetChild(i).gameObject);
                      }
                      transform.GetChild(transform.childCount - 1).gameObject.SetActive(false);
                      gameObject.GetComponent<MeshRenderer>().enabled = true;
                      gameObject.GetComponent<BakeIngre>().bakeouttime = 0;
                      gameObject.GetComponent<BakeIngre>().heattime = 0;*/
                    Destroy(gameObject);
                    return ;
                }

                for (int i = 0; i < transform.GetChild(0).childCount; i++)
                {
                    transform.GetChild(0).GetChild(i).gameObject.SetActive(false);
                }
              
            }
           Instantiate(particle, Repos.position, particle.transform.rotation);
            gameObject.transform.position = Repos.position;
            gameObject.transform.rotation = Repos.rotation;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            nowDrop = false;
        }
    }
}
