using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StickButton : MonoBehaviour
{
    public static bool stick;

    Image image;
    public Sprite[] sprite = new Sprite[2];
    public GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        image = transform.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Onclick()
    {
        if (image.sprite.name == "Option_off")
        {
            image.sprite = sprite[0];      
            saves.stick = true;
        }
        else if (image.sprite.name == "Option_on")
        {
            image.sprite = sprite[1];
            saves.stick = false;       
        }
    }
}
