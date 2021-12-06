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
        randomWord = dictionary.words[Random.Range(0, dictionary.words.Count)];
        randomWord = randomWord.Substring(0, randomWord.Length - 1);
        randomWord = randomWord.ToUpper();
    }
}
