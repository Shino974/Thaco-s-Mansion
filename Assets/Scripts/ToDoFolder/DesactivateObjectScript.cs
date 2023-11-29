using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivateObjectScript : MonoBehaviour
{
    public int timer;
    public GameObject toDestroy;
    void Start()
    {
        StartCoroutine(nameof(DisableObject));
    }

    private IEnumerator DisableObject()
    {
        yield return new WaitForSeconds(timer);
        toDestroy.SetActive(false);
    }
}
