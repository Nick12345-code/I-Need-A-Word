using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class ButtonGenerator : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] Player player;
    [Space]
    [SerializeField] GameObject letterButton;
    [SerializeField] Transform letterHolder;
    [SerializeField] List<GameObject> letterButtons = new List<GameObject>();
    char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

    public void GenerateButtons()
    {
        foreach (char letter in alphabet)
        {
            GameObject a = Instantiate(letterButton);
            a.transform.SetParent(letterHolder);
            a.GetComponentInChildren<TextMeshProUGUI>().text = letter.ToString();
            a.transform.GetComponent<Button>().onClick.AddListener(player.CheckLetter);
            letterButtons.Add(a);
        }
    }

    public void UpdateButtons(bool interactable)
    {
        foreach (GameObject button in letterButtons)
        {
            button.GetComponent<Button>().interactable = interactable;
        }
    }
}
