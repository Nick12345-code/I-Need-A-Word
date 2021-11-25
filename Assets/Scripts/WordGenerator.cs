using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class WordGenerator : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] WordDictionary dictionary;
    [Space]
    public string randomWord;
    
    public void GenerateRandomWord()
    {
        System.Random rand = new System.Random();
        List<string> temp = dictionary.words.ElementAt(rand.Next(0, dictionary.words.Count)).Value;
        randomWord = temp[Random.Range(0, temp.Count)];
        randomWord = randomWord.ToUpper();
    } 
}
