using UnityEngine;

public class Player1Controller : PlayerController
{
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
