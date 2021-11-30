using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI iqText;
    public int iq;
    public int iqStandard = 1;
    public int iqMultiplier = 5;

    void Start()
    {
        iq = 0;
        iqText.text = iq.ToString();
    }

    public void IncreaseIQ(int amount)
    {
        iq += amount;
        iqText.text = iq.ToString() + " IQ";
    }
}
