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
        if(string.Equals(collision.gameObject.tag, "Player"))
        {
            var playerInventory = collision.gameObject.GetComponent<PlayerInventory>();
            Debug.Log(gameObject.name);
            playerInventory.AddObjectToInventory(Veggie);
            
            //check if player inventory is full
            //if player inventory is not full 
            // create an object and add it into the inventory of the player

        }
    }
}
