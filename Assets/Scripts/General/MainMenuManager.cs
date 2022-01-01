using UnityEngine;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI totalCorrectLettersText;
    [SerializeField] TextMeshProUGUI totalCorrectWordsText;
    GameData gameData;

    void Awake() => gameData = SaveSystem.Load();

    void Start() => RefreshUI();

    public void RefreshUI()
    {
        totalCorrectLettersText.text = gameData.totalCorrectLetters.ToString();
        totalCorrectWordsText.text = gameData.totalCorrectWords.ToString();
    }


}
