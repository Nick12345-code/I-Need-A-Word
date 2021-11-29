using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] Animator animator;
    string sceneName;

    public void FadeOut(string _sceneName)
    {
        sceneName = _sceneName;
        animator.SetTrigger("FadeOut");
    }

    public void FadeComplete()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(sceneName);
    }
}
