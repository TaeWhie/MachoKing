using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public float moveSpeed;
    Vector2 prevPos = Vector2.zero;
    Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        //cam = Camera.main.transform;
    }
    public void DragOn()
    {
      // if(prevPos==Vector2.zero)
      //  {
      //      prevPos = Input.mousePosition;
      //     return;
      //  }
        //Vector2 dir;// = ((Input.mousePosition) - prevPos).normalized;
       // dir.x = Input.mousePosition.x-prevPos.x;
      //  dir.y = Input.mousePosition.y-prevPos.y;
       // dir= dir.normalized;
       // Quaternion q = new Quaternion.Eular(dir.x, 0.0f, dir.y,0.0f);
       // cam.rotation -= q;
      //  prevPos = Input.mousePosition;
    }
    public void DragOff()
    {
       // prevPos = Vector2.zero;
    }
    // Update is called once per frame
    void Update()
    {

        //  transform.LookAt(Input.mousePosition);
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.left * 20.0f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.right * 20.0f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.forward * 20.0f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.back * 20.0f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * 20.0f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.down * 20.0f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * 1.0f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * 1.0f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * 1.0f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * 1.0f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.Translate(Vector3.up * 1.0f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.down * 1.0f * Time.deltaTime);
        }
       
    }
}
