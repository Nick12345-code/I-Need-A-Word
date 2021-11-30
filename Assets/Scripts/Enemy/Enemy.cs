using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] WordUI ui;
    [SerializeField] WordGenerator word;
    [Space]
    public bool hadTurn;
    [Header("AI")]
    public float enemyThinkingTime;
    public char chosenLetter;
    [SerializeField, Range(0, 1)] float vowelChance = 0.20f;
    [SerializeField, Range(0, 1)] float commonsChance = 0.60f;
    [Header("Letters")]
    public List<char> alphabet = new List<char>{ 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
    public List<char> vowels = new List<char> { 'A', 'E', 'I', 'O', 'U' };
    public List<char> commons = new List<char> { 'R', 'T', 'N', 'S', 'L', 'C' };

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
                RemoveLetter();
                LoseCheck();
                hadTurn = true;
                return;
            }
        }

        foreach (char letter in word.randomWord)
        {
            if (letter != chosenLetter)
            {
                RemoveLetter();              
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
        GameManager.Instance.hasLost = true;
    }

    char GetRandomLetter()
    {
        float randomValue = Random.value;

        if (randomValue <= vowelChance) // 20% Probability
        {
            if (vowels.Count != 0)
            {
                return vowels[Random.Range(0, vowels.Count)]; 
            }
        }
        else if (randomValue <= commonsChance) // 40% Probability
        {
            if (commons.Count != 0)
            {
                return commons[Random.Range(0, commons.Count)];
            }
        }

        return alphabet[Random.Range(0, alphabet.Count)];
    }

    void RemoveLetter()
    {
        alphabet.Remove(chosenLetter);
        vowels.Remove(chosenLetter);
        commons.Remove(chosenLetter);
    }
}
