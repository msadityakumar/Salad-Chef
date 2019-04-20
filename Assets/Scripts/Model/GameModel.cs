
[System.Serializable]
public class GameModel
{
    /// <summary>
    /// Player1Inventory stores the player1 data
    /// </summary>
    public PlayerInventory Player1Inventory;

    /// <summary>
    /// Player2Inventory stores the player2 data
    /// </summary>
    public PlayerInventory Player2Inventory;

    /// <summary>
    /// Total game time which will be assigned to both players
    /// </summary>
    public float GameTime;

    public PlayerInventory GetPlayerInventory(string playerIdentifier)
    {
        if (playerIdentifier == "Player1")
            return Player1Inventory; 
        else
            return Player2Inventory;
    }
}
