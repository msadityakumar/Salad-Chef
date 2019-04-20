using UnityEngine;

public class VeggiePlate : MonoBehaviour, IInteractable<InteractionType>
{
    private bool m_IsInteracting;
    private PlayerController m_playerController;
    private Vegetable m_VeggieHolder;
    private Color m_PlateDefaultColor;
    private SpriteRenderer m_SpriteRenderer;

    void Start()
    {
        m_playerController = null;
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_PlateDefaultColor = m_SpriteRenderer.color;
    }

    // collision triggers
    public void OnTriggerEnter2D(Collider2D collision)
    {
        AssignInteractable(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
      //  AssignInteractable(collision);
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

    public void CompleteInteraction()
    {
        m_IsInteracting = false;
    }

    public void Interact(InteractionType type)
    {
        //started interaction
            if (m_VeggieHolder == null && type == InteractionType.PlaceDown)
            {
                m_IsInteracting = true;
                var veggie = m_playerController.PlayerInventory.RemoveVeggieFromInventory();
                AssignVeggieToPlate(veggie);
                m_SpriteRenderer.color = veggie.VeggieColor;
            }
            else if(m_VeggieHolder != null && type == InteractionType.Pickup)
            {
                m_IsInteracting = true;
                m_playerController.PlayerInventory.AddObjectToInventory(m_VeggieHolder);
                m_VeggieHolder = null;
                m_SpriteRenderer.color = m_PlateDefaultColor;
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
    }

    void Update()
    {
        if (m_playerController)
        {
            var color = m_SpriteRenderer.color;
            m_SpriteRenderer.color = new Color(color.r, color.g, color.b, 0.5f);
        }
        else
        {
            var color = m_SpriteRenderer.color;
            m_SpriteRenderer.color = new Color(color.r, color.g, color.b, 1f);
        }
    }
}
