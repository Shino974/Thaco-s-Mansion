using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicsManager : MonoBehaviour
{
    public GameObject camCar;
    public GameObject cam2;
    public GameObject player;
    public GameObject car;
    
    void Start()
    {
        StartCoroutine(nameof(DisableAfterSecond));        
        StartCoroutine(nameof(EnableAfterSecond));
    }
    private IEnumerator DisableAfterSecond()
    {
        yield return new WaitForSeconds(23);
        cam2.GetComponent<AudioBehaviour>().enabled = true;
        camCar.SetActive(false); 
    }
    
    private IEnumerator EnableAfterSecond()
    {
        yield return new WaitForSeconds(30);
        player.SetActive(true); 
        cam2.SetActive(false);
        car.GetComponent<AudioSource>().enabled = false;
    }
}
