using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePlayer : MonoBehaviour
{
    public int timer;
    public GameObject player;
    
    void Start()
    {
        StartCoroutine(nameof(EnableAfterSecond));
    }
    private IEnumerator EnableAfterSecond()
    {
        yield return new WaitForSeconds(timer);
        player.SetActive(true); 
    }
}
