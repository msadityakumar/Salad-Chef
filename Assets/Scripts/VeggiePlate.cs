using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeggiePlate : MonoBehaviour, IInteractable<PlayerController>
{
    private bool m_IsInteracting;
    private PlayerController m_playerController;

    private Vegetable m_VeggieHolder;

    void Start()
    {
        m_playerController = null;
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
        if (m_playerController)
            ExitInteractable();
    }

    public bool CanStartInteraction()
    {
        if (m_IsInteracting)
            return false;

        return true;
    }

    public void ExitInteractable()
    {
        m_IsInteracting = false;
        m_playerController.RemoveInteractable();
    }

    public void Interact(PlayerController objectToInteract)
    {
        //started interaction
        m_IsInteracting = true;
        if (objectToInteract.GetType() == typeof(PlayerController))
        {
            m_playerController = objectToInteract;
            if (m_VeggieHolder == null)
            {
                var veggie = m_playerController.PlayerInventory.RemoveVeggieFromInventory();
                AssignVeggieToPlate(veggie);
            }
            else
            {
                m_playerController.PlayerInventory.AddObjectToInventory(m_VeggieHolder);
                m_VeggieHolder = null;
                Debug.Log("Plate Is empty");
            }
        }
        else
        {
            Debug.LogError("Only player controller can interact with objects");
        }
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

    public bool IsInteracting()
    {
        return m_IsInteracting;
    }

    public void ReadyForInteraction()
    {
        if (m_IsInteracting)
            return;
    }

    void AssignVeggieToPlate(Vegetable veggie)
    {
        m_VeggieHolder = veggie;
        Debug.Log("Veggie Assigned to Plate");
    }
}
