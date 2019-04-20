using UnityEngine;

public enum InteractionType
{
    Pickup,
    PlaceDown
}

public class PlayerController : MonoBehaviour
{
    public PlayerInventory PlayerInventory;
    public float Speed = 5f;
    private IInteractable<InteractionType> m_Interactable;

    [SerializeField] private string InputHorizontalAxis;
    [SerializeField] private string InputVerticalAxis;
    protected bool m_FreezePlayer = false;

    protected void BaseUpdate()
    {
        float xAxis = Input.GetAxis(InputHorizontalAxis);
        float yAxis = Input.GetAxis(InputVerticalAxis);

        Vector3 movement = new Vector3(xAxis * Time.deltaTime * Speed, yAxis * Time.deltaTime * Speed, 0f);
        this.gameObject.transform.Translate(movement);

    }

    public void InteractWithObject(InteractionType type)
    {
        if (m_Interactable != null && m_Interactable.CanStartInteraction())
        {
            m_Interactable.Interact(type);
            m_Interactable.CompleteInteraction();
        }
    }

    public IInteractable<InteractionType> GetInteractable()
    {
        return m_Interactable;
    }

    public void RemoveInteractable()
    {
        m_Interactable = null;
    }

    public void AssignInteractable(IInteractable<InteractionType> interactable)
    {
        if (m_Interactable != null)
            m_Interactable = null;
        m_Interactable = interactable;
    }

    public void FreezePlayer(bool status)
    {
        m_FreezePlayer = status;
    }
}
