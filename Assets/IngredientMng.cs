using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientMng : MonoBehaviour
{
    public GameObject Ingredient;

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.childCount==2)
        {
            GameObject Clone = Instantiate(Ingredient, gameObject.transform.position, Ingredient.transform.rotation);
            Clone.transform.parent = gameObject.transform;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="hand")
        {
            gameObject.transform.GetChild(2).transform.position = other.transform.position;
        }
    }
}
