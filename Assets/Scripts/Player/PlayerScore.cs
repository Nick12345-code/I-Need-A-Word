using UnityEngine;
using UnityEngine.UI;   
using TMPro;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] float points;
    public float Points
    {
        get { return points; }
        set
        {
            if (points == value) return;
            points = value;
            if (points <= 0)
            {
                GameManager.Instance.hasLost = true;
            }
        }
    }
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
