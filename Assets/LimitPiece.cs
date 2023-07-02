using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitPiece : MonoBehaviour
{
    public int Max;
    public GameObject changePiece;
    public GameObject Particle;
    // Update is called once per frame
    void Update()
    {
        if(transform.childCount>=Max)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
            if(changePiece)
            {
                Vector3 Amount=Vector3.zero;
                for (int i = 0; i < transform.childCount; i++)
                {
                    Amount += transform.GetChild(i).transform.position;
                }
                Amount = Amount / transform.childCount;
                Instantiate(Particle, Amount, changePiece.transform.rotation);
                Instantiate(changePiece, Amount, changePiece.transform.rotation);
            }
        }
    }
}
