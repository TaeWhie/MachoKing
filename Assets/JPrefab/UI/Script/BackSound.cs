using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;
public class BackSound : MonoBehaviour
{
    Button button;
    Image image;
    public Sprite[] sprite=new Sprite[2];
    public GameObject character;
    SpriteState spriteState = new SpriteState();
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
        if(image.sprite.name== "Option_off")
        {
            image.sprite = sprite[0];
            character.GetComponent<AudioSource>().enabled = true;
            saves.sound = true;
        }
        else if(image.sprite.name == "Option_on")
        {
            image.sprite = sprite[1];
            character.GetComponent<AudioSource>().enabled = false;
            saves.sound = false;
        }
    }
}
