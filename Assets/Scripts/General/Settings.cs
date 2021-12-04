using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider sfxVolumeSlider;
    [SerializeField] float defaultMusicVolume = 0.5f;
    [SerializeField] float defaultSFXVolume = 0.5f;

    void Start() => SetupSettings();

    void SetupSettings()
    {
        if (!PlayerPrefs.HasKey("MusicVolume")) musicVolumeSlider.value = defaultMusicVolume;
        else musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");

        if (!PlayerPrefs.HasKey("SFXVolume")) sfxVolumeSlider.value = defaultSFXVolume;
        else sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }

    public void OnChangeMusicVolume(float sliderValue)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }

    public void OnChangeSFXVolume(float sliderValue)
    {
        mixer.SetFloat("SFXVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("SFXVolume", sliderValue);
    }
}
