using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject baseMenuPanel;
    public GameObject settingsPanel;
    public GameObject creditsPanel;
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    
    public void OpenSettings()
    {
        baseMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
    
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        baseMenuPanel.SetActive(true);
    }
    
    public void OpenCredit()
    {
        baseMenuPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }
    
    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
        baseMenuPanel.SetActive(true);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
