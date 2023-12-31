using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            else if (InventoryScript.lettersCount == 5 || InventoryScript.lettersCount == 6)
            {
                SceneManager.LoadScene("EndGame2");
            }
            else if (InventoryScript.lettersCount == 7)
            {
                SceneManager.LoadScene("EndGame");
            }
        }
        if (other.gameObject.CompareTag("toDestroy"))
        {
            other.gameObject.GetComponent<ToDoScript>().DisableObject();
            Destroy(other);
        }
        
        if (other.gameObject.CompareTag("toScare"))
        {
            other.gameObject.GetComponent<ToDoScript>().ActivateObject();
            Destroy(other);
        }
    }
}
