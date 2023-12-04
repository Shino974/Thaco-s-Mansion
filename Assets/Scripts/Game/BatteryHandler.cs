using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BatteryHandler : MonoBehaviour
{
    private CamRayCast crc;
    public TMP_Text batteryText;
    private int batteryLevel = 100;
    public GameObject flashLight;
    private bool flashLightIsActive = false;
    
    private void Start()
    {
        InvokeRepeating("UseBattery", 32, 1);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            if (flashLightIsActive == false && batteryLevel > 0)
            {
                flashLight.SetActive(true);
                flashLightIsActive = true;
            }
            else if (flashLightIsActive)
            {
                flashLight.SetActive(false);
                flashLightIsActive = false;
            }
        }
    }
    
    public void UseBattery()
    {
        if (flashLightIsActive == true && batteryLevel > 0)
        {
            batteryLevel--; 
            batteryText.text = batteryLevel + "%";  
        }
        else
        {
            flashLight.SetActive(false);
        }
    }

    public void ReloadBattery()
    {
        batteryLevel = 100;
        batteryText.text = batteryLevel + "%";
    }
}
