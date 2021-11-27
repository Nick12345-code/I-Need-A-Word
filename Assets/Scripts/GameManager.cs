using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool playerWon;
    public static bool playerLost;

    void Start()
    {
        playerWon = false;
        playerLost = false;
    }


}
