using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] WordDictionary dictionary;
    public string randomWord;

    public void GetRandomWordFromDictionary() => randomWord = dictionary.words[Random.Range(0, dictionary.words.Count)];
}
