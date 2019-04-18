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

        if (playerData.Salad == null)
        {
            CombinationText.text = "Salad: Empty";
        }
        else
        {
            CombinationText.text = GetTextFromQueue(playerData.Salad);
        }
    }

    string GetTextFromQueue(Salad salad)
    {
        string saladStr = "Salad: ";
        int i = 0;
        while (i < salad.GetSize())
        {
            var veggie = salad.GetElementAt(i);
            saladStr += veggie.VegetableCode.ToString()+ " ";
            i++;
        }
        return saladStr;
    }
}
