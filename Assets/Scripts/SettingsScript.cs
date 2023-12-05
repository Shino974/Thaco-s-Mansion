using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    private void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0f);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0f);
        sfxSlider.value = PlayerPrefs.GetFloat("SfxVolume", 0f);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }
    public void SetMusic(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
    public void SetSfx(float volume)
    {
        audioMixer.SetFloat("SfxVolume", volume);
        PlayerPrefs.SetFloat("SfxVolume", volume);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
