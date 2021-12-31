using UnityEngine;
using SmokeTest;
using System;

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
    public Action<int> OnGainIQ;

    void Awake()
    {
        gameData = SaveSystem.Load();
        OnGainIQ += ReportAchievementProgress;
    }

    public void UpdateCorrectWordsCount()
    {
        gameData.correctWords += 1;
        SaveSystem.Save(gameData);
    }

    public void SaveIQ()
    {
        gameData.iqTotal += player.playerScore.iq;
        OnGainIQ(gameData.iqTotal);
        SaveSystem.Save(gameData);
        ReportHighscore();
    }

    void ReportHighscore()
    {
        if (GooglePlayManager.Instance.isConnectedToGooglePlayServices)
        {
            Social.ReportScore(gameData.iqTotal, GPGSIds.leaderboard_iq, (success) => 
            {
                if (!success) Debug.LogError("Unable to post highscore!");
            });
        }
        else Debug.LogError("Not Signed In! Unable to post highscore!");
    }

    void ReportAchievementProgress(int iqAmount)
    {
        switch (iqAmount)
        {
            case 10:
                Social.ReportProgress(GPGSIds.achievement_big_brain, 20.0f, null);
                break;
            case 20:
                Social.ReportProgress(GPGSIds.achievement_big_brain, 20.0f, null);
                break;
            case 30:
                Social.ReportProgress(GPGSIds.achievement_big_brain, 20.0f, null);
                break;
            case 40:
                Social.ReportProgress(GPGSIds.achievement_big_brain, 20.0f, null);
                break;
            case 50:
                Social.ReportProgress(GPGSIds.achievement_big_brain, 20.0f, null);
                break;
            default:
                break;
        }
    }
}
