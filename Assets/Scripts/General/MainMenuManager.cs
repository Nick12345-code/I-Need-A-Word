using UnityEngine;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    GameData gameData;
    [SerializeField] TextMeshProUGUI iqText;

    void Awake()
    {
        gameData = SaveSystem.Load();
        RefreshUI();
    }

    void RefreshUI()
    {
        iqText.text = gameData.iqTotal.ToString() + " IQ";
    }
}
