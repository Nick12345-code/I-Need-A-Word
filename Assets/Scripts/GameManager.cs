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

    public bool hasWon;
    public bool hasLost;
    public float timerValue;

    void Awake() => DontDestroyOnLoad(gameObject);





}
