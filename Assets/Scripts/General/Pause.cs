using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] int numTouchesToPause = 2;
    [SerializeField] bool isPaused;

    void Start() => menu.SetActive(false);

    void Update()
    {
        if (Input.touchCount == numTouchesToPause && !isPaused) PauseGame();
        else if (Input.touchCount == numTouchesToPause && isPaused) ResumeGame();
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0.0f;
        menu.SetActive(true);
    }

    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
        menu.SetActive(false);
    }
}
