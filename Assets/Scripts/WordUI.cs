using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordUI : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] WordGenerator wordGenerator;
    [Header("Setup")]
    public Transform playerPanel;
    public Transform enemyPanel;
    [Header("Lists")]
    public List<GameObject> playerLetters = new List<GameObject>();
    public List<GameObject> enemyLetters = new List<GameObject>();

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
}
