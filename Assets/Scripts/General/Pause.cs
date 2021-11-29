using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject menu;

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
        menu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        menu.SetActive(false);
    }
}
