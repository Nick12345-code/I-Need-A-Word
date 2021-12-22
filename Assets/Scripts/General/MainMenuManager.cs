using UnityEngine;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI iqText;
    GameData gameData;

    void Start()
    {
        gameData = SaveSystem.Load();
        UpdateIQ();
    }

    public void UpdateIQ() => iqText.text = gameData.iqTotal.ToString() + " IQ";
}
