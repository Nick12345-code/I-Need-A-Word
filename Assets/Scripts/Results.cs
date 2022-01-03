using UnityEngine;
using System.Collections;
using TMPro;

public class Results : MonoBehaviour
{
    [SerializeField] WordGenerator wordGenerator;
    [SerializeField] GameObject resultsPanel;
    [SerializeField] TextMeshProUGUI resultsText;
    [SerializeField] TextMeshProUGUI wordText;
    public string winSentence, loseSentence;
    WaitForSeconds resultsDelay = new WaitForSeconds(3);

    public void ShowResults(string result, string word)
    {
        resultsText.text = result;
        wordText.text = "The word was " + word;
        resultsPanel.SetActive(true);
    }

    public void StartWinSequence() => StartCoroutine(WinSequence());
    public void StartLoseSequence() => StartCoroutine(LoseSequence());

    IEnumerator WinSequence()
    {
        // confetti
        yield return resultsDelay;
        ShowResults(winSentence, wordGenerator.randomWord);
        yield break;
    }

    IEnumerator LoseSequence()
    {
        // particle effect
        yield return resultsDelay;
        ShowResults(loseSentence, wordGenerator.randomWord);
        yield break;
    }

}
