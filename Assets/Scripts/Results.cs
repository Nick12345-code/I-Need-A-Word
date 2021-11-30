using UnityEngine;
using TMPro;

public class Results : MonoBehaviour
{
    [SerializeField] GameObject resultsPanel;
    [SerializeField] TextMeshProUGUI resultsText;
    [SerializeField] TextMeshProUGUI wordText;
    public string winSentence, loseSentence;

    public void ShowResults(string result, string word)
    {
        resultsText.text = result;
        wordText.text = "The word was " + word;
        resultsPanel.SetActive(true);
    }
}
