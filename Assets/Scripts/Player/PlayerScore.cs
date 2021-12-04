using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI iqText;
    public int iq;
    public int iqIncreaseAmount = 1;

    void Start() => SetupIQ();

    void SetupIQ()
    {
        iq = 0;
        iqText.text = iq.ToString() + " IQ";
    }

    public void IncreaseIQ(int amount)
    {
        iq += amount;
        iqText.text = iq.ToString() + " IQ";
    }

    public void DecreaseIQ(int amount)
    {
        if (iq <= 0) return;
        iq -= amount;
        iqText.text = iq.ToString() + " IQ";
    }

}
