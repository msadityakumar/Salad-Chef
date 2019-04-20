using UnityEngine;

public class StartGameScreen : MonoBehaviour
{
    void Awake()
    {
        Time.timeScale = 0f;
    }

    public void StartButtonAction()
    {
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
    }
}
