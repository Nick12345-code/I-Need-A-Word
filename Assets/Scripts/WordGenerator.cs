using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class WordGenerator : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] WordDictionary dictionary;
    [Space]
    public string randomWord;
    
    public void GetRandomWordFromDictionary()
    {
        System.Random randomValue = new System.Random(dictionary.words.Count);
        randomWord = dictionary.listOfWords[Random.Range(0, dictionary.listOfWords.Count)];
        randomWord = randomWord.Substring(0, randomWord.Length - 1);
    }
}
