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
                print(word.Length);
                words.Add(word);
            }
        }
    }

    // function find string greater than
    // length k
    static void string_k(string s, int k)
    {
        // create the empty string
        string w = "";

        // iterate the loop till every space
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != ' ')

                // append this sub string in
                // string w
                w = w + s[i];
            else
            {

                // if length of current sub
                // string w is greater than
                // k then print
                if (w.Length > k)
                    Console.Write(w + " ");
                w = "";
            }
        }
    }

    // Driver code
    static void Main()
    {
        string s = "geek for geeks";
        int k = 3;
        s = s + " ";
        string_k(s, k);
    }

}
