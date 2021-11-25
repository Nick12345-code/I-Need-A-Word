using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordUI : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] WordGenerator wordGenerator;
    [Header("Setup")]
    [SerializeField] GridLayoutGroup playerGridLayout;
    [SerializeField] GridLayoutGroup enemyGridLayout;
    public Transform playerPanel;
    public Transform enemyPanel;
    [Header("Lists")]
    public List<GameObject> playerLetters = new List<GameObject>();
    public List<GameObject> enemyLetters = new List<GameObject>();
    [Header("Fall Effect")]
    [SerializeField, Range(10, 100)] float minXForce = 10.0f;
    [SerializeField, Range(10, 100)] float maxXForce = 100.0f;
    [SerializeField, Range(10, 100)] float minYForce = 10.0f;
    [SerializeField, Range(10, 100)] float maxYForce = 100.0f;

    void Start()
    {
        playerGridLayout.enabled = true;
        enemyGridLayout.enabled = true;
    }

    public void GenerateLetters(Transform panel, List<GameObject> list)
    {
        foreach (char letter in wordGenerator.randomWord)
        {
            GameObject a = ObjectPool.sharedInstance.GetPooledObject();
            a.transform.SetParent(panel);
            a.GetComponentInChildren<TextMeshProUGUI>().text = letter.ToString();
            list.Add(a);
            a.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
            a.GetComponent<Rigidbody2D>().isKinematic = true;
            a.SetActive(true);
        }
    }

    public void GameOverEffect()
    {
        playerGridLayout.enabled = false;
        enemyGridLayout.enabled = false;

        foreach (GameObject letterBox in playerLetters)
        {
            letterBox.GetComponent<Rigidbody2D>().isKinematic = false;
            letterBox.GetComponent<Rigidbody2D>().AddForce(GetRandomForce(), ForceMode2D.Impulse);
        }

        foreach (GameObject letterBox in enemyLetters)
        {
            letterBox.GetComponent<Rigidbody2D>().isKinematic = false;
            letterBox.GetComponent<Rigidbody2D>().AddForce(GetRandomForce(), ForceMode2D.Impulse);
        }
    }

    Vector2 GetRandomForce()
    {
        Vector2 randomValue = new Vector2(Random.Range(minXForce, maxXForce), Random.Range(minYForce, maxYForce));
        return randomValue;
    }
}
