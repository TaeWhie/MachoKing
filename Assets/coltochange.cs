using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coltochange : MonoBehaviour
{
    public GameObject changeobj;
    public GameObject particle;
    public string colobj;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "Waittag")
        {
            StartCoroutine(waitsec());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == colobj&&gameObject.tag=="Food")
        {
            if(collision.collider is CapsuleCollider&& collision.gameObject.GetComponent<Move>().ReturnVelocity().sqrMagnitude >= 5f)
            {
                Debug.Log(collision.gameObject.GetComponent<Move>().ReturnVelocity().sqrMagnitude);
                Instantiate(particle, gameObject.transform.position, particle.transform.rotation);
                if(gameObject.name=="1dough(Clone)")
                {
                    Instantiate(changeobj, gameObject.transform.position+new Vector3(0.176f,0,0), changeobj.transform.rotation);
                }
                else if(gameObject.name=="2dough(Clone)")
                {
                    Instantiate(changeobj, gameObject.transform.position-new Vector3(0.176f, 0, 0), changeobj.transform.rotation);
                }
                else
                {
                 Instantiate(changeobj, gameObject.transform.position, changeobj.transform.rotation);
                }
                collision.gameObject.GetComponent<SoundPlayer>().playsound(1, false);
                Destroy(gameObject);
            }
        }
    }
    IEnumerator waitsec()
    {
        yield return new WaitForSeconds(1f);
        gameObject.tag = "Food";

    }
}
