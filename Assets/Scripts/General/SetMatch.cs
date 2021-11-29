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

    void Start()
    {
        SetupTime();
    }

    void SetupTime()
    {
        timeSlider.value = timeValue;
        timeSlider.maxValue = maxTime;
        timeSlider.minValue = minTime;
        timeText.text = "Time Allowed: " + timeValue.ToString() + " Seconds";
    }

    public void ChangeTime()
    {
        timeValue = (int)timeSlider.value;
        PlayerPrefs.SetInt("Time", timeValue);
        timeText.text = "Time Allowed: " + timeValue.ToString() + " Seconds";
    }

}
