using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCam2SFX : MonoBehaviour
{
    public int timer;
    public GameObject cam2;
    
    void Start()
    {
        StartCoroutine(nameof(EnableAfterSecond));
    }
    private IEnumerator EnableAfterSecond()
    {
        yield return new WaitForSeconds(timer);
        cam2.GetComponent<AudioBehaviour>().enabled = true;
    }
}
