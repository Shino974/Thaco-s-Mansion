using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisabelCarSFX : MonoBehaviour
{
    public int timer;
    public GameObject car;
    
    void Start()
    {
        StartCoroutine(nameof(DisableAfterSecond));
    }
    private IEnumerator DisableAfterSecond()
    {
        yield return new WaitForSeconds(timer);
        car.GetComponent<AudioSource>().enabled = false;
    }
}
