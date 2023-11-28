using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharactereCollision : MonoBehaviour
{
    private TextManager tm;

    private void Start()
    {
        tm = GameObject.Find("GameManager").GetComponent<TextManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "EndGame")
        {
            if (InventoryScript.lettersCount < 5)
            {
                tm.ShowTextForSecondOnDial("Need to find all indice");
            }
            else if (InventoryScript.lettersCount == 5)
            {
                tm.ShowTextForSecondOnDial("Bad Ending");
                Destroy(other.gameObject);
            }
            else if (InventoryScript.lettersCount == 7)
            {
                tm.ShowTextForSecondOnDial("True Ending");
                Destroy(other.gameObject);
            }
        }
    }
}
