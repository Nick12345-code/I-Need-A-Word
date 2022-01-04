using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class Results : MonoBehaviour
{
    [SerializeField] WordGenerator wordGenerator;
    [SerializeField] WordUI wordUI;
    [SerializeField] GameObject resultsPanel;
    [SerializeField] TextMeshProUGUI resultsText;
    [SerializeField] TextMeshProUGUI wordText;
    public string winSentence, loseSentence;
    WaitForSeconds delay = new WaitForSeconds(3);
    EventSystem eventSystem;
    [Header("Game Over Effect")]
    [SerializeField] Color winColor;
    [SerializeField] float colorChangeTime = 2.5f;

    void Awake() => eventSystem = FindObjectOfType<EventSystem>();

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
        eventSystem.enabled = false;

        foreach (GameObject letter in wordUI.playerLetters)
        {
            letter.GetComponentInChildren<Image>().CrossFadeColor(winColor, colorChangeTime, true, false);
        }

        yield return delay;

        ShowResults(winSentence, wordGenerator.randomWord);
        eventSystem.enabled = true;

        yield break;
    }

    IEnumerator LoseSequence()
    {
        eventSystem.enabled = false;

        foreach (GameObject letter in wordUI.enemyLetters)
        {
            letter.GetComponentInChildren<Image>().CrossFadeColor(winColor, colorChangeTime, true, false);
        }

        yield return delay;

        ShowResults(loseSentence, wordGenerator.randomWord);
        eventSystem.enabled = true;

        yield break;
    }

}
