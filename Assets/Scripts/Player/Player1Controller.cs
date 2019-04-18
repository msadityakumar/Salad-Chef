using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : PlayerController
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ///if player is freezed stop everything for this player
        if (m_FreezePlayer)
            return;
        BaseUpdate();

        if (Input.GetKeyDown(KeyCode.Q))
           {
               InteractWithObject(InteractionType.Pickup);
           }

        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractWithObject(InteractionType.PlaceDown);
        }
    }
}
