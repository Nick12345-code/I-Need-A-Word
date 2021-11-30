using UnityEngine;
using UnityEngine.UI;   
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 10.0f;
    public float Health
    {
        get { return health; }
        set
        {
            if (health == value) return;
            health = value;
            if (health <= 0)
            {
                GameManager.Instance.hasLost = true;
            }
        }
    }
    [SerializeField] float maxHealth;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] Image fill;

    void Start()
    {
        health = maxHealth;
        healthText.text = health.ToString("0");
        fill.fillAmount = health / maxHealth;
    }

    public void LoseHealth(float amount)
    {
        health -= amount;
        healthText.text = health.ToString("0");
        fill.fillAmount = health / maxHealth;
    }
}
