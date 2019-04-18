using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour, IInteractable<InteractionType>
{
    public TextMesh CustomerSaladText;
    public float WaitingTimeForEachVeggie = 4f;
    private bool m_IsInteracting;
    private PlayerController m_playerController;
    private Salad m_CustomerSalad;
    private float m_TotalWaitingTime = 0f;
    private float m_Progress = 1f;
    private float m_PassedTime = 0f;
    void Start()
    {
        m_CustomerSalad = this.GetComponent<CustomerSaladGenerator>().GetCustomerSalad();
        m_TotalWaitingTime = m_CustomerSalad.GetSize() * WaitingTimeForEachVeggie;
        CustomerSaladText.text = m_CustomerSalad.GetSaladStringFromSalad();
    }

    // Update is called once per frame
    void Update()
    {
        m_PassedTime += Time.deltaTime;
        float currentWaitTime = m_TotalWaitingTime - m_PassedTime;
        if (currentWaitTime <= 0)
        {
            //stop timer
           
            //TODO: reduce score for both
            GameObject.Destroy(this.gameObject);
            return;
        }

        m_Progress = currentWaitTime / m_TotalWaitingTime;
    }

    public float GetProgress()
    {
        return m_Progress;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        AssignInteractable(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (m_playerController)
            ExitInteractable();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        AssignInteractable(collision);
    }

    public void AssignInteractable(Collider2D collision)
    {
        if (!IsInteracting() && !m_playerController)
        {
            var playerController = collision.gameObject.GetComponent<PlayerController>();
            m_playerController = playerController;
            playerController.AssignInteractable(this);
        }
    }

    public bool CanStartInteraction()
    {
        if (m_IsInteracting)
            return false;

        return true;
    }

    public void CompleteInteraction()
    {
        m_IsInteracting = false;
    }

    public void ExitInteractable()
    {
        m_IsInteracting = false;
        if (m_playerController)
        {
            m_playerController.RemoveInteractable();
            m_playerController = null;
        }
}

    public void Interact(InteractionType InteractionType)
    {
        if (InteractionType == InteractionType.PlaceDown)
        {
            var  playerSalad = m_playerController.PlayerInventory.GetPlayerData().Salad;
            bool areSaladsEqual = playerSalad.Equals(m_CustomerSalad);

            if(areSaladsEqual)
                Debug.Log("both salads are equal");
            else 
                Debug.Log("Both salads are unequal");
           
        }
    }

    public bool IsInteracting()
    {
        return m_IsInteracting;
    }

    public void ReadyForInteraction()
    {
        if(m_IsInteracting)
            return;
        ///display visual feedback that the interactable is ready for interaction.
    }
}
