using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMgr : MonoBehaviour
{
    public  string[]Pieces;
    public int[] MaxPiece;
    public GameObject[] PiecesObject;
    public GameObject[] Particle;
    // Start is called before the first frame update
    private void Awake()
    {
        for (int i = 0; i < Pieces.Length; i++)
        {
            GameObject emptyGameObject = new GameObject(Pieces[i]);
            emptyGameObject.AddComponent<LimitPiece>().Max = MaxPiece[i];
            emptyGameObject.GetComponent<LimitPiece>().changePiece = PiecesObject[i];
            emptyGameObject.GetComponent<LimitPiece>().Particle = Particle[i];
        }
        Destroy(gameObject);
    }
}
