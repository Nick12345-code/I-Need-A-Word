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
    public bool HasWon
    {
        get { return hasWon; }
        set
        {
            if (hasWon == value) return;
            hasWon = value;
            if (hasWon)
            {
                SaveIQ();
            }
        }
    }
    public bool hasLost;
    [Header("Save System")]
    public GameData gameData;
    public Player player;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        gameData = SaveSystem.Load();
        player = FindObjectOfType<Player>();
    }    

    void SaveIQ()
    {
        gameData.iqTotal += player.playerScore.iq;
        SaveSystem.Save(gameData);
    }
}
