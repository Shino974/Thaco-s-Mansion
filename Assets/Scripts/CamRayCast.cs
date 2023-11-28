using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRayCast : MonoBehaviour
{
    private Outline ol;
    public TextManager textManager;

    private void FixedUpdate()
    {
        RaycastHit hit;
        GameObject hittenGameObject;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if (hit.transform.gameObject.CompareTag("letters"))
            {
                hittenGameObject = hit.transform.gameObject;
                ol = hittenGameObject.GetComponent<Outline>();
                ol.enabled = true;
            }
            else
            {
                hittenGameObject = null;
                if (ol != null)
                    ol.enabled = false;
                ol = null;
            }

            if ((Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.E)) && hittenGameObject != null)
            {
                Destroy(hittenGameObject);
                InventoryScript.lettersCount++;
                switch (hittenGameObject.name)
                {
                    case "MondayLetter":
                        textManager.ShowText(textManager.mondayLetter);
                        break;
                }
            }
        }
    }
}
