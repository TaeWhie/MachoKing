using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Waittag 와 Cuttertag 필요
public class Cut : MonoBehaviour
{
    // Start is called before the first frame update
    public Material capMaterial;
    GameObject[] gameObjects;
    Vector3 Yetvector;
    Vector3 NewVector;
    public string ingredient;
    private bool onBoard=false;
    public bool nowCut = true;
    void Start()
    {
        if(gameObject.tag=="Waittag")
        {
            StartCoroutine(waitsec());
        }
      //  gameObjects = MeshCut.Cut(gameObject, transform.position, new Vector3(0,1,0.5f), capMaterial);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collobj;


        if (collision.gameObject.tag == "Board")
        {
            onBoard = true;
        }

        if (collision.gameObject.GetComponent<Cutter>())
        {
            collobj = collision.gameObject;

        }
        else
        {
            Debug.Log("Not Cutter");
            return;
        }

        if (collobj.tag == "Cutter"&& gameObject.tag=="Food"&&onBoard==true&&collision.collider is CapsuleCollider)
        {
            if (collobj.GetComponent<Move>().ReturnVelocity().sqrMagnitude >= 0.5f)
            {
                Quaternion RotVec = collision.transform.rotation;

                gameObjects = MeshCut.Cut(gameObject, collision.contacts[0].point,
                new Vector3(-0.7f+collision.transform.rotation.y, -collision.transform.rotation.z, collision.transform.rotation.y), capMaterial);
                collobj.GetComponent<SoundPlayer>().playsound(1,false);
                Debug.Log("Cut");
                gameObject.tag = "Waittag";
                StartCoroutine(waitsec());
            }
            else
            {
                Debug.Log(collobj.GetComponent<Move>().ReturnVelocity().sqrMagnitude);
                Debug.Log("Not Enough speed");
            }
        }
        else
        {
            if (!collobj.GetComponent<AudioSource>().isPlaying)
            {
                collobj.GetComponent<SoundPlayer>().playsound(0, false);
            }
            Debug.Log("Not Sharp");
        }
    }
    IEnumerator waitsec()
    {
        yield return new WaitForSeconds(1f);
        gameObject.tag = "Food";

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Board")
        {
            onBoard = false;
        }
    }
}

   
