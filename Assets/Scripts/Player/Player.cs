using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] WordUI ui;
    [SerializeField] WordGenerator generator;
    [SerializeField] PlayerScore score;
    [Space]
    [SerializeField] KeyCode showKeyboardKey;
    [SerializeField] GameObject keyboardPanel;
    public GameObject selected;
    public bool hadTurn;
    public bool playerWon;

    public void CheckIfPlayerChoseCorrectLetter()
    {
        selected = EventSystem.current.currentSelectedGameObject;

        foreach (char letter in generator.randomWord)
        {
            if (letter.ToString() == selected.GetComponentInChildren<TextMeshProUGUI>().text)
            {
                Result(Color.green);

                foreach (GameObject letterText in ui.playerLetters)
                {
                    if (letterText.GetComponentInChildren<TextMeshProUGUI>().text == selected.GetComponentInChildren<TextMeshProUGUI>().text)
                    {
                        letterText.GetComponentInChildren<TextMeshProUGUI>().enabled = true;
                    }
                }
                CheckIfPlayerHasWon();
                keyboardPanel.SetActive(false);
                hadTurn = true;
                return;
            }
        }

        foreach (char letter in generator.randomWord)
        {
            if (letter.ToString() != selected.GetComponentInChildren<TextMeshProUGUI>().text)
            {
                Result(Color.red);
                score.LosePoints(1);
                keyboardPanel.SetActive(false);
                hadTurn = true;
                return;
            }
        }
    }

    void Result(Color color)
    {
        selected.GetComponent<Button>().enabled = false;
        selected.GetComponent<Button>().targetGraphic.color = color;
    }

    void CheckIfPlayerHasWon()
    {
        foreach (GameObject letter in ui.playerLetters)
        {
            if (!letter.GetComponentInChildren<TextMeshProUGUI>().enabled) return;
        }
        playerWon = true;
    }

    public void ShowKeyboard()
    {
        if (keyboardPanel.activeInHierarchy) keyboardPanel.SetActive(false);
        else keyboardPanel.SetActive(true);
    }
}
