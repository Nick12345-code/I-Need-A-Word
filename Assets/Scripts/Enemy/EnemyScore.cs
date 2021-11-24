using UnityEngine;
using TMPro;

public class EnemyScore : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] int maxPoints;
    [SerializeField] TextMeshProUGUI pointsText;
    public int points;
    public int Points
    {
        get { return points; }
        set
        {
            if (points == value) return;
            points = value;
            if (points == 0)
            {
                player.playerWon = true;
            }
        }
    }

    void Start()
    {
        points = maxPoints;
        pointsText.text = points.ToString();
    }

    public void LosePoints(int amount)
    {
        points -= amount;
        pointsText.text = points.ToString();
    }
}
