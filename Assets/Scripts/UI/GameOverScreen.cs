using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text Player1ScoreText;

    public Text Player2ScoreText;
    // Start is called before the first frame update
    void OnEnable()
    {
        Player1ScoreText.text =
            "Player1Score: " + GameController.Instance.GameModel.Player1Inventory.GetPlayerData().PlayerScore.ToString();
        Player2ScoreText.text =
            "Player2Score: " + GameController.Instance.GameModel.Player2Inventory.GetPlayerData().PlayerScore.ToString();
    }
}
