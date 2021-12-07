using System.Collections.Generic;
using UnityEngine;

public class WordDictionary : MonoBehaviour
{
    [SerializeField] int minLetters = 3;
    [SerializeField] TextAsset txt;
    string[] dictionary;
    public List<string> words = new List<string>();
    
    void Awake()
    {
        LoadPlayerPreferences();
        LoadWordsFromFile();
    }

    void LoadPlayerPreferences() => minLetters = PlayerPrefs.GetInt("MinWordLength");

    void LoadWordsFromFile()
    {
        dictionary = txt.text.Split("\n"[0]);
        AddWordsToList();
    }

    void AddWordsToList()
    {
        foreach (string word in dictionary)
        {
            if (word.Length >= minLetters)
            {
                words.Add(word);
            }
        }
    }
}
