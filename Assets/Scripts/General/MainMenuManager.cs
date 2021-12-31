using UnityEngine;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI iqText;
    [SerializeField] TextMeshProUGUI correctWordsText;
    public GameData gameData;

    void Start()
    {
        gameData = SaveSystem.Load();
        UpdateIQ();
        UpdateCorrectWords();
    }

    public void UpdateIQ() => iqText.text = gameData.iqTotal.ToString() + " IQ";

    public void UpdateCorrectWords() => correctWordsText.text = gameData.correctWords.ToString() + " Correct Words";
}
