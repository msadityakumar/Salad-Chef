using UnityEngine;

public class Customer : MonoBehaviour, IInteractable<InteractionType>
{
    public TextMesh CustomerSaladText;
    public float WaitingTimeForEachVeggie = 4f;
    public int CustomerIndex { get; set; }
    public CustomerSpawner CustSpawnerRef;

    [SerializeField] private int m_CustomerLeftAngryPoints;
    [SerializeField] private int m_ScoreForEachVeggie;
    private bool m_IsInteracting;
    private PlayerController m_playerController;
    private Salad m_CustomerSalad;
    private float m_TotalWaitingTime = 0f;
    private float m_Progress = 1f;
    private float m_PassedTime = 0f;
    private SpriteRenderer m_SpriteRenderer;

    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_CustomerSalad = this.GetComponent<CustomerSaladGenerator>().GetCustomerSalad();
        m_TotalWaitingTime = m_CustomerSalad.GetSize() * WaitingTimeForEachVeggie;
        CustomerSaladText.text = m_CustomerSalad.GetSaladStringFromSalad();
    }

    void Update()
    {
        m_PassedTime += Time.deltaTime;
        float currentWaitTime = m_TotalWaitingTime - m_PassedTime;
        if (currentWaitTime <= 0)
        {
            //stop timer
           GameController.Instance.GameModel.Player1Inventory.AddScoreToPlayer(m_CustomerLeftAngryPoints);
           GameController.Instance.GameModel.Player2Inventory.AddScoreToPlayer(m_CustomerLeftAngryPoints);

            CustSpawnerRef.DestroyCustomerAtIndex(CustomerIndex);
            return;
        }

        m_Progress = currentWaitTime / m_TotalWaitingTime;

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
     //   AssignInteractable(collision);
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
        CustSpawnerRef.DestroyCustomerAtIndex(CustomerIndex);
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
            int playerSaladSize = playerSalad.GetSize();
            bool areSaladsEqual = playerSalad.Equals(m_CustomerSalad);

            if (areSaladsEqual)
            {
                //got the right salad
                int score = playerSaladSize * m_ScoreForEachVeggie;
                m_playerController.PlayerInventory.AddScoreToPlayer(score);
                playerSalad.ScrapSalad();
            }
            else
            {
             //The customer got wrong salad.
                m_playerController.PlayerInventory.AddScoreToPlayer(m_CustomerLeftAngryPoints);
            }

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
