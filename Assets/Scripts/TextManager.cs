using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TMP_Text text;
    public GameObject panelLetters;
    
    public string mondayLetter;
    public string tuesdayLetter;
    public string wednesdayLetter;
    public string thursdayLetter;
    public string fridayLetter;
    public string saturdayLetter;
    public string sundayLetter;

    public void ShowText(string txt)
    {
        panelLetters.SetActive(true);
        text.text = txt;
    }

    public void HideText()
    {
        panelLetters.SetActive(false);
        text.text = "";
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            HideText();
        }
    }
}
