using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoard : MonoBehaviour, IInteractable<InteractionType>
{
    [SerializeField] private float m_TimeForChoppingVeggies = 2f;
    private bool m_IsInteracting;
    private PlayerController m_playerController;
    private Salad m_CuttingBoardSalad;

    void Start()
    {
        m_CuttingBoardSalad = new Salad();
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AssignInteractable(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        AssignInteractable(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (m_playerController)
            ExitInteractable();
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

    public void ExitInteractable()
    {
        m_IsInteracting = false;
        if (m_playerController)
        {
            m_playerController.RemoveInteractable();
            m_playerController = null;
        }
    }

    public void Interact(InteractionType type)
    {
        ///get veggie fron player
        /// if veggie is empty do nothing
        /// two interactable things
        /// 1) add to salad
        /// 2) take salad from board
        /// empty the salad
        /// while chopping freeze player and choppin board
        /// So many things :/

       
        if (type == InteractionType.PlaceDown)
        {
            m_IsInteracting = true;
            var veggie = m_playerController.PlayerInventory.RemoveVeggieFromInventory();

            if (veggie != null)
            {
                m_playerController.FreezePlayer(true);
                StartCoroutine(AddVeggieToSalad(veggie));
            }
        }
        else if(type == InteractionType.Pickup)
        {
            m_IsInteracting = true;

            while (m_CuttingBoardSalad.GetSize() > 0)
                m_playerController.PlayerInventory.AddVeggiesToSalad(m_CuttingBoardSalad.Dequeue());
            
            m_CuttingBoardSalad.ScrapSalad();
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
        ///change the display of the character
    }

    public void CompleteInteraction()
    {
        m_IsInteracting = false;
    }

    IEnumerator AddVeggieToSalad(Vegetable veggie)
    {
        //Freeze player and Cutting Board
        //play chopping sound for interaction
        yield return new WaitForSeconds(m_TimeForChoppingVeggies);

        m_CuttingBoardSalad.AddVeggieToSalad(veggie);
        m_playerController.FreezePlayer(false);
    }
}
