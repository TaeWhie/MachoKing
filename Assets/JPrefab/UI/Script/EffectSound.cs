using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EffectSound : MonoBehaviour
{
    Button button;
    Image image;
    public Sprite[] sprite;
    SpriteState spriteState = new SpriteState();
    // Start is called before the first frame update
    void Start()
    {
        image = this.gameObject.transform.GetComponent<Image>();
        button = this.gameObject.transform.GetComponent<Button>();
        spriteState = button.spriteState;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Onclick()
    {
        if (image.sprite == sprite[0])
        {
            image.sprite = sprite[2];
            spriteState.pressedSprite = sprite[3];
        }
        else
        {
            image.sprite = sprite[0];
            spriteState.pressedSprite = sprite[1];
        }
        button.spriteState = spriteState;

    }
}
