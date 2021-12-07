using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<GameManager>();
            return instance;
        }
    }
    [Header("Player States")]
    public bool hasWon;
    public bool hasLost;
    [Header("Save System")]
    public GameData gameData;
    public Player player;

    void Awake() => gameData = SaveSystem.Load();

    public void SaveIQ()
    {
        gameData.iqTotal += player.playerScore.iq;
        SaveSystem.Save(gameData);
    }
}
