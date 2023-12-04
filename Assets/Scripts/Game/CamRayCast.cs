using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CamRayCast : MonoBehaviour
{
    private Outline ol;
    public TextManager textManager;
    public AudioClip paperSFX;
    public AudioClip reloadSFX;

    private void Update()
    {
        RaycastHit hit;
        GameObject hittenGameObject;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if (hit.transform.gameObject.CompareTag("letters"))
            {
                hittenGameObject = hit.transform.gameObject;
                ol = hittenGameObject.GetComponent<Outline>();
                ol.enabled = true;
            }
            else if (hit.transform.gameObject.CompareTag("battery"))
            {
                hittenGameObject = hit.transform.gameObject;
                ol = hittenGameObject.GetComponent<Outline>();
                ol.enabled = true;
            }
            else
            {
                hittenGameObject = null;
                if (ol != null)
                    ol.enabled = false;
                ol = null;
            }

            if (Input.GetKeyUp(KeyCode.E) && hittenGameObject != null)
            {
                Destroy(hittenGameObject);
                if (hittenGameObject.CompareTag("battery"))
                {
                    GameObject.Find("GameManager").GetComponent<BatteryHandler>().ReloadBattery();
                    GetComponent<AudioSource>().PlayOneShot(reloadSFX);
                }
                else
                {
                    InventoryScript.lettersCount++;
                    GetComponent<AudioSource>().PlayOneShot(paperSFX);
                    switch (hittenGameObject.name)
                    {
                        case "MondayLetter":
                            textManager.ShowText(textManager.textLetters[0]);
                            break;
                        case "TuesdayLetter":
                            textManager.ShowText(textManager.textLetters[1]);
                            break;
                        case "WednesdayLetter":
                            textManager.ShowText(textManager.textLetters[2]);
                            break;
                        case "ThursdayLetter":
                            textManager.ShowText(textManager.textLetters[3]);
                            break;
                        case "FridayLetter":
                            textManager.ShowText(textManager.textLetters[4]);
                            break;
                        case "SaturdayLetter":
                            textManager.ShowText(textManager.textLetters[5]);
                            break;
                        case "SundayLetter":
                            textManager.ShowText(textManager.textLetters[6]);
                            break;
                    }
                }
            }
        }
    }
}
