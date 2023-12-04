using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionScript : MonoBehaviour
{
    public GameObject canvaDial;
    public AudioSource audioSource;
    public AudioClip audioClip;
    void Start()
    {
        StartCoroutine(nameof(StartIntroduction));
        StartCoroutine(nameof(EndIntroduction));
    }
    private IEnumerator StartIntroduction()
    {
        yield return new WaitForSeconds(30);
        canvaDial.SetActive(true);
        audioSource.PlayOneShot(audioClip);
    }

    private IEnumerator EndIntroduction()
    {
        yield return new WaitForSeconds(45);
        canvaDial.SetActive(false);
    }
}
