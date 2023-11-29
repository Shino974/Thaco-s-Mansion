using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDoScript : MonoBehaviour
{
    public GameObject[] toActivate;    

    public void DisableObject()
    {
        foreach (GameObject go in toActivate)
        {
            go.SetActive(false);
        }
        Destroy(this);
    }
    
    public void ActivateObject()
    {
        foreach (GameObject go in toActivate)
        {
            go.SetActive(true);
        }
        Destroy(this);
    }
}
