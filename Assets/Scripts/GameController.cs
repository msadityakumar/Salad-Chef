using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    public GameModel GameModel;
    public UIManager UiManager;
    private int m_PlayerFinishedCount = 0;

    void OnEnable()
    {
        Instance = this;
    }

    void OnDisable()
    {
        if (Instance == this)
            Instance = null;
    }

    public void RegisterGameOver()
    {
        m_PlayerFinishedCount++;
        if(m_PlayerFinishedCount >= 2)
        UiManager.ShowGameOverScreen();
    }
}
