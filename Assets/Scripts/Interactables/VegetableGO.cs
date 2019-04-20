using UnityEngine;

public class VegetableGO : MonoBehaviour, IInteractable<InteractionType>
{
    public Vegetable Veggie;
    public TextMesh VeggieText;
    private bool m_IsInteracting;
    private PlayerController m_playerController;
    private SpriteRenderer m_SpriteRenderer;
    void Start()
    {
        m_IsInteracting = false;
        m_SpriteRenderer = this.GetComponent<SpriteRenderer>();
        var veggieSpriteRenderer = GetComponent<SpriteRenderer>();
        veggieSpriteRenderer.color = Veggie.VeggieColor;
        VeggieText.text = Veggie.VegetableCode.ToString();

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
       // AssignInteractable(collision);
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
        if (m_playerController != null && m_playerController.GetInteractable() != null)
        {
            if (m_playerController.GetInteractable().Equals(this.gameObject))
            {
                m_playerController.RemoveInteractable();
            }

        }
        m_playerController = null;
    }

    public void CompleteInteraction()
    {
        m_IsInteracting = false;
    }

    public bool CanStartInteraction()
    {
        if(m_IsInteracting)
            return false;

        return true;
    }

    public void Interact(InteractionType type)
    {
        //started interaction
        if (type ==InteractionType.Pickup)
        {
            m_IsInteracting = true;
            m_playerController.PlayerInventory.AddObjectToInventory(Veggie);
        }
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
