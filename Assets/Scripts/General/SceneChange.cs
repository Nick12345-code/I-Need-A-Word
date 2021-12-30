using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneChange : MonoBehaviour
{
    [SerializeField] AudioSource musicAudioSource;
    [SerializeField] float secondsToFadeOut = 1.0f;
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

    public void FadeAudio()
    {
        StartCoroutine(FadeAudioCoroutine());
    }

    IEnumerator FadeAudioCoroutine()
    {
        while (musicAudioSource.volume > 0.01f)
        {
            musicAudioSource.volume -= Time.deltaTime / secondsToFadeOut;
            yield return null;
        }
        musicAudioSource.volume = 0.0f;
    }
}
