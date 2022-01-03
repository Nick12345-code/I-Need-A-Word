using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] int numTouchesToPause = 2;
    [SerializeField] bool isPaused;

    void Start() => menu.SetActive(false);

    void Update()
    {
        if (Input.touchCount > 1)
        {
            Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Began)
            {
                if (!isPaused) PauseGame();
                else if (isPaused)ResumeGame();
            }
        }
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
