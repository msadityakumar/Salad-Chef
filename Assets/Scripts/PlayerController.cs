using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 5f;
    private IInteractable<PlayerController> m_Interactable;

    [SerializeField] private string InputHorizontalAxis;
    [SerializeField] private string InputVerticalAxis;

    public PlayerInventory PlayerInventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis(InputHorizontalAxis);
        float yAxis = Input.GetAxis(InputVerticalAxis);

        Vector3 movement = new Vector3(xAxis * Time.deltaTime * Speed, yAxis * Time.deltaTime * Speed, 0f);
        this.gameObject.transform.Translate(movement);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (m_Interactable != null && m_Interactable.CanStartInteraction())
            {
                m_Interactable.Interact(this);
                m_Interactable.InteractionComplete();
            }
        }
    }

    public void RemoveInteractable()
    {
        m_Interactable = null;
    }

    public IInteractable<PlayerController> GetCurrentInteractable()
    {
        return m_Interactable;
    }

    public void AssignInteractable(IInteractable<PlayerController> interactable)
    {
        if(m_Interactable == null)
        m_Interactable = interactable;
    }
}
