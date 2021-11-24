using UnityEngine;
using TMPro;

public class Results : MonoBehaviour
{
    [SerializeField] GameObject resultsPanel;
    [SerializeField] TextMeshProUGUI resultsText;
    public string winSentence, loseSentence;

    public void ShowResults(string result)
    {
        resultsText.text = result;
        resultsPanel.SetActive(true);
    }
}
