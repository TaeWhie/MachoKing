using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Recipe : MonoBehaviour
{
    public string nextScene;
    public Sprite[] sprite;
    Image image;

 
    // Start is called before the first frame update
    void Start()
    {
        image = transform.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void OnClick()
    {
        SceneManager.LoadScene(nextScene);
        image.sprite = sprite[1];
    }

}

