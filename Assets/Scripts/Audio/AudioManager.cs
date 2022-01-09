using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource sfxAudioSource;

    public void PlaySound(AudioClip audioClip) => sfxAudioSource.PlayOneShot(audioClip);

}
