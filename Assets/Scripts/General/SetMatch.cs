using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetMatch : MonoBehaviour
{
    [Header("Words")]
    [SerializeField] Slider wordLengthSlider;
    [SerializeField] TextMeshProUGUI wordLengthText;
    [SerializeField] int wordLength = 8;
    [SerializeField] int minWordLength = 5;
    [SerializeField] int maxWordLength = 11;

    void Start() => SetupWordLength();

    void SetupWordLength()
    {
        wordLengthSlider.value = wordLength;
        wordLengthSlider.minValue = minWordLength;
        wordLengthSlider.maxValue = maxWordLength;
        wordLengthText.text = "Minimum Word Length: " + wordLength.ToString() + " Letters";
    }

    public void ChangeWordLength()
    {
        wordLength = (int)wordLengthSlider.value;
        PlayerPrefs.SetInt("MinWordLength", wordLength);
        wordLengthText.text = "Minimum Word Length: " + wordLength.ToString() + " Letters";
    }
}
