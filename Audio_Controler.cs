using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Controler : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    
    public void audioSFX(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
