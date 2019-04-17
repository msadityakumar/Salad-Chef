using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableGO : MonoBehaviour, IInteractable<PlayerController>
{
    public Vegetable Veggie;
    private bool m_IsInteracting;
    private PlayerController m_playerController;
    void Start()
    {
        m_IsInteracting = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsInteracting())
            {
                var playerController = collision.gameObject.GetComponent<PlayerController>();
                playerController.AssignInteractable(this);
            }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(m_playerController)
            ExitInteractable();
    }


    /// implementing IInteractableInterface

    public void ReadyForInteraction()
    {
        if(m_IsInteracting)
            return;
        ///change the display of the character
    }

    public bool IsInteracting()
    {
        return m_IsInteracting;
    }
    public void ExitInteractable()
    {
        m_IsInteracting = false;
        m_playerController.RemoveInteractable();

    }

    public bool CanStartInteraction()
    {
        if(m_IsInteracting)
            return false;

        return true;
    }

    public void InteractionComplete()
    {
        m_IsInteracting = false;

        if (!m_playerController)
        {
           m_playerController.RemoveInteractable();
        }
        else
        {
            Debug.LogError("Only player controller can interact with objects");
        }

    }

    public void Interact(PlayerController objectToInteract)
    {
        //started interaction
        m_IsInteracting = true;
        if (objectToInteract.GetType() == typeof(PlayerController))
        {
            m_playerController = objectToInteract;
            m_playerController.PlayerInventory.AddObjectToInventory(Veggie);
        }
        else
        {
            Debug.LogError("Only player controller can interact with objects");
        }
    }
}
