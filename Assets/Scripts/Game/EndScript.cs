using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        audioMixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume"));
        audioMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));
        audioMixer.SetFloat("SfxVolume", PlayerPrefs.GetFloat("SfxVolume"));
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
