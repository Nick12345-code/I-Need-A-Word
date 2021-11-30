using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetMatch : MonoBehaviour
{
    [Header("Timer")]
    [SerializeField] Slider timeSlider;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] int timeValue = 180;
    [SerializeField] int minTime = 60;
    [SerializeField] int maxTime = 300;
    [Header("Words")]
    [SerializeField] Slider wordLengthSlider;
    [SerializeField] TextMeshProUGUI wordLengthText;
    [SerializeField] int wordLength = 8;
    [SerializeField] int minWordLength = 5;
    [SerializeField] int maxWordLength = 11;

    void Start()
    {
        SetupTimer();
        SetupWordLength();
    }

    void SetupTimer()
    {
        timeSlider.value = timeValue;
        timeSlider.minValue = minTime;
        timeSlider.maxValue = maxTime;
        timeText.text = "Time Allowed: " + timeValue.ToString() + " Seconds";
    }

    void SetupWordLength()
    {
        wordLengthSlider.value = wordLength;
        wordLengthSlider.minValue = minWordLength;
        wordLengthSlider.maxValue = maxWordLength;
        wordLengthText.text = "Minimum Word Length: " + wordLength.ToString() + " Letters";
    }

    public void ChangeTime()
    {
        timeValue = (int)timeSlider.value;
        PlayerPrefs.SetInt("Time", timeValue);
        timeText.text = "Time Allowed: " + timeValue.ToString() + " Seconds";
    }

    public void ChangeWordLength()
    {
        wordLength = (int)wordLengthSlider.value;
        PlayerPrefs.SetInt("MinWordLength", wordLength);
        wordLengthText.text = "Minimum Word Length: " + wordLength.ToString() + " Letters";
    }

}
