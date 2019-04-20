using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject GameOverScreen;
   public void ShowGameOverScreen()
    {
        GameOverScreen.SetActive(true);
    }
}
