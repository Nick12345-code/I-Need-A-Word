using UnityEngine;
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
    public Action<int> OnCorrectLetter;
    public Action<int> OnCorrectWord;

    void Awake()
    {
        gameData = SaveSystem.Load();
        OnCorrectLetter += ReportTotalCorrectLetters;
        OnCorrectWord += ReportTotalCorrectWords;
    }

    public void IncreaseCorrectLetters()
    {
        gameData.totalCorrectLetters += player.playerScore.correctLetters;
        OnCorrectLetter(gameData.totalCorrectLetters);
        SaveSystem.Save(gameData);
        ReportCorrectLettersHighscore();
    }

    public void IncreaseCorrectWords()
    {
        gameData.totalCorrectWords += 1;
        OnCorrectWord(gameData.totalCorrectWords);
        SaveSystem.Save(gameData);
        ReportCorrectWordsHighscore();
    }

    #region Reporting Leaderboard Progress

    void ReportCorrectLettersHighscore()
    {
        if (GooglePlayManager.Instance.isConnectedToGooglePlayServices)
        {
            Social.ReportScore(gameData.totalCorrectLetters, GPGSIds.leaderboard_correct_letters, (success) => 
            {
                if (!success) Debug.LogError("Unable to post highscore!");
            });
        }
        else Debug.LogError("Not Signed In! Unable to post highscore!");
    }

    void ReportCorrectWordsHighscore()
    {
        if (GooglePlayManager.Instance.isConnectedToGooglePlayServices)
        {
            Social.ReportScore(gameData.totalCorrectWords, GPGSIds.leaderboard_correct_words, (success) =>
            {
                if (!success) Debug.LogError("Unable to post highscore!");
            });
        }
        else Debug.LogError("Not Signed In! Unable to post highscore!");
    }

    #endregion

    #region Reporting Achievement Progress

    void ReportTotalCorrectLetters(int totalCorrectLetters)
    {
        switch (totalCorrectLetters)
        {
            case 200:
                Social.ReportProgress(GPGSIds.achievement_etymologist, 20.0f, null);
                break;
            case 400:
                Social.ReportProgress(GPGSIds.achievement_etymologist, 20.0f, null);
                break;
            case 600:
                Social.ReportProgress(GPGSIds.achievement_etymologist, 20.0f, null);
                break;
            case 800:
                Social.ReportProgress(GPGSIds.achievement_etymologist, 20.0f, null);
                break;
            case 1000:
                Social.ReportProgress(GPGSIds.achievement_etymologist, 20.0f, null);
                break;
            default:
                break;
        }
    }

    void ReportTotalCorrectWords(int totalCorrectWords)
    {
        switch (totalCorrectWords)
        {
            case 200:
                Social.ReportProgress(GPGSIds.achievement_wordsmith, 20.0f, null);
                break;
            case 400:
                Social.ReportProgress(GPGSIds.achievement_wordsmith, 20.0f, null);
                break;
            case 600:
                Social.ReportProgress(GPGSIds.achievement_wordsmith, 20.0f, null);
                break;
            case 800:
                Social.ReportProgress(GPGSIds.achievement_wordsmith, 20.0f, null);
                break;
            case 1000:
                Social.ReportProgress(GPGSIds.achievement_wordsmith, 20.0f, null);
                break;
            default:
                break;
        }
    }

    #endregion
}
