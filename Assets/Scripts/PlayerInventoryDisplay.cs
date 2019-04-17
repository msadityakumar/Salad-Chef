using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryDisplay : MonoBehaviour
{
    public string PlayerIdentifier;
    public Text PlayerSlot1Text;
    public Text PlayerSlot2Text;
    public Text CombinationText;

    void Start()
    {
        
    }

    void Update()
    {
        PlayerInventory playerInventory = GameController.Instance.GameModel.GetPlayerInventory(PlayerIdentifier);
        PlayerData playerData = playerInventory.GetPlayerData();

        if (playerData.Veggie1 == null)
        {
            PlayerSlot1Text.text = "Empty";
        }
        else
        {
            PlayerSlot1Text.text = playerData.Veggie1.VegetableName;
        }

        if (playerData.Veggie2 == null)
        {
            PlayerSlot2Text.text = "Empty";
        }
        else
        {
            PlayerSlot2Text.text = playerData.Veggie2.VegetableName;
        }
        
        
    }
}
