using System;
using System.Collections.Generic;
using UnityEngine;

public class WordDictionary : MonoBehaviour
{
    [SerializeField] int minLetters = 3;
    [SerializeField] int maxLetters = 11;
    [SerializeField] TextAsset txt;
    string[] dictionary;
    public List<string> words = new List<string>();
    

    void Awake()
    {
        LoadPlayerPreferences();
        LoadWordsFromFile();
    }

    void LoadPlayerPreferences()
    {
        minLetters = PlayerPrefs.GetInt("MinWordLength");
        print(minLetters);
    }

    void LoadWordsFromFile()
    {
        dictionary = txt.text.Split("\n"[0]);
        AddWordsToList();
    }

    void AddWordsToList()
    {
        foreach (string word in dictionary)
        {
            word.Substring(0, word.Length - 1);

            if (word.Length >= minLetters && word.Length <= maxLetters)
            {
                words.Add(word);
            }
        }
    }
}
