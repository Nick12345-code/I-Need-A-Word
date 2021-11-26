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
        System.Random randomValue = new System.Random();
        List<string> temp = dictionary.words.ElementAt(randomValue.Next(0, dictionary.words.Count)).Value;
        randomWord = temp[Random.Range(0, temp.Count)];
        randomWord = randomWord.Substring(0, randomWord.Length - 1);
    }
}
