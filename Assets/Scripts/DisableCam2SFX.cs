using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCam2SFX : MonoBehaviour
{
    public int timer;
    public GameObject cam2;
    
    void Start()
    {
        StartCoroutine(nameof(DisableAfterSecond));
    }
    private IEnumerator DisableAfterSecond()
    {
        yield return new WaitForSeconds(timer);
        cam2.GetComponent<AudioListener>().enabled = false;
    }
}
