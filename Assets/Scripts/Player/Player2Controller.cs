using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : PlayerController
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        ///if player is freezed stop everything for this player
        if (m_FreezePlayer)
            return;
        BaseUpdate();

        if (Input.GetKeyDown(KeyCode.Period))
        {
            InteractWithObject(InteractionType.Pickup);
        }

        if (Input.GetKeyDown(KeyCode.Slash))
        {
            InteractWithObject(InteractionType.PlaceDown);
        }
    }
}
