using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TMP_Text textLetter;
    public GameObject panelLetters;
    public TMP_Text textDial;
    public GameObject panelDial;

    public string[] textLetters;

    public void ShowText(string txt)
    {
        panelLetters.SetActive(true);
        textLetter.text = txt;
    }

    public void ShowTextForSecondOnDial(string txt)
    {
        panelDial.SetActive(true);
        textDial.text = txt;
        StartCoroutine(nameof(HideTextAfterSeconds));
    }

    IEnumerator HideTextAfterSeconds()
    {
        yield return new WaitForSeconds(5);
        HideTextOnDial();
    }

    public void HideText()
    {
        panelLetters.SetActive(false);
        textLetter.text = "";
    }
    
    public void HideTextOnDial()
    {
        panelDial.SetActive(false);
        textLetter.text = "";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            HideText();
        }
    }
}
