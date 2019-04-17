using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableGO : MonoBehaviour
{
    public Vegetable Veggie;

    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
    //On trigger 
        if(string.Equals(collision.gameObject.tag, "Player1"))
        {
            var playerInventory = GameController.Instance.GameModel.Player1Inventory;
            Debug.Log(gameObject.name);
            playerInventory.AddObjectToInventory(Veggie);
        }else if (string.Equals(collision.gameObject.tag, "Player2"))
        {
            var playerInventory = GameController.Instance.GameModel.Player2Inventory;
            Debug.Log(gameObject.name);
            playerInventory.AddObjectToInventory(Veggie);
        }
    }
}
