using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] EnemyScore score;
    [SerializeField] WordUI ui;
    [SerializeField] WordGenerator word;
    [Space]
    public bool hadTurn;
    public bool playerLost;
    [Header("Computer AI")]
    public float enemyThinkingTime;
    public char chosenLetter;
    [SerializeField, Range(0, 1)] float vowelChance = 0.20f;
    public List<char> alphabet = new List<char>{ 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
    public List<char> vowels = new List<char> { 'A', 'E', 'I', 'O', 'U' };

    public void CheckRandomLetter()
    {
        chosenLetter = GetRandomLetter(); 

        foreach (char letter in word.randomWord)
        {
            if (letter == chosenLetter)
            {
                foreach (GameObject letterText in ui.enemyLetters)
                {
                    if (chosenLetter.ToString() == letterText.GetComponentInChildren<TextMeshProUGUI>().text)
                    {
                        letterText.GetComponent<Image>().color = Color.yellow;
                    }
                }
                alphabet.Remove(chosenLetter);
                vowels.Remove(chosenLetter);
                LoseCheck();
                hadTurn = true;
                return;
            }
        }

        foreach (char letter in word.randomWord)
        {
            if (letter != chosenLetter)
            {
                score.LosePoints(1);
                alphabet.Remove(chosenLetter);
                vowels.Remove(chosenLetter);
                hadTurn = true;
                return;
            }
        }
    }

    void LoseCheck()
    {
        foreach (GameObject letter in ui.enemyLetters)
        {
            if (letter.GetComponent<Image>().color != Color.yellow) return;
        }
        playerLost = true;
    }

    char GetRandomLetter()
    {
        float randomValue = Random.value;

        if (randomValue <= vowelChance)
        {
            if (vowels.Count != 0)
            {
                return vowels[Random.Range(0, vowels.Count)]; 
            }
        }

        return alphabet[Random.Range(0, alphabet.Count)];
    }
}
