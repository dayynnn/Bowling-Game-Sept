using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CloseUpCamera : MonoBehaviour
{
    [SerializeField] private GameObject alternateCamera;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            alternateCamera.SetActive(true);
            Invoke("TurnOffCamera", 2.5f);
        }
    }

    private void TurnOffCamera()
    {
        alternateCamera.SetActive(false);
    }
}
