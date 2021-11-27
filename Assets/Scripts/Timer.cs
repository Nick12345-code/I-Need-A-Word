using UnityEngine;
using System.Collections;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] int timeValue = 120;
    WaitForSeconds oneSecond = new WaitForSeconds(1);

    void Start()
    {
        DisplayTime(timeValue);
        StartCoroutine(Countdown(timeValue));
    }

    IEnumerator Countdown(int seconds)
    {
        timeValue = seconds;

        while (timeValue > 0)
        {
            yield return oneSecond;
            timeValue--;
            DisplayTime(timeValue);
        }

        StopCountdown();
    }

    void DisplayTime(int time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timeText.text = string.Format("{00}:{1:00}", minutes, seconds);
    }

    void StopCountdown()
    {
        StopCoroutine("Countdown");
        timeValue = 0;
        GameManager.playerLost = true;
    }
}
