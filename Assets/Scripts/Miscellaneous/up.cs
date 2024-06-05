using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.UIElements;

public class up : MonoBehaviour
{
    
    [SerializeField] AudioClip WarpClip;
    [SerializeField] Audio_Controler ac;
    public Transform mudar;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ac.audioSFX(WarpClip);
            other.transform.position = mudar.transform.position;
        }

    }
}
