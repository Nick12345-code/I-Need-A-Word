using UnityEngine;

public class Keyboard : MonoBehaviour
{
    [SerializeField] GameObject keyboardPanel;

    public void UpdateKeyboard()
    {
        if (keyboardPanel.activeInHierarchy) keyboardPanel.SetActive(false);
        else keyboardPanel.SetActive(true);
    }
}
