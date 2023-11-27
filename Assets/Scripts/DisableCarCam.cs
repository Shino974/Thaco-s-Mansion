using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCarCam : MonoBehaviour
{
    public int timer;
    public GameObject carCam;
    
    void Start()
    {
        StartCoroutine(nameof(DisableAfterSecond));
    }
    private IEnumerator DisableAfterSecond()
    {
        yield return new WaitForSeconds(timer);
        carCam.SetActive(false); 
    }
}
