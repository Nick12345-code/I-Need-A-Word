using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyScore : MonoBehaviour
{
    [SerializeField] float points;
    [SerializeField] float maxPoints;
    [SerializeField] TextMeshProUGUI pointsText;
    [SerializeField] Image fill;

    void Start()
    {
        points = maxPoints;
        pointsText.text = points.ToString("0");
        fill.fillAmount = points / maxPoints;
    }

    public void LosePoints(float amount)
    {
        points -= amount;
        pointsText.text = points.ToString("0");
        fill.fillAmount = points / maxPoints;
    }
}
