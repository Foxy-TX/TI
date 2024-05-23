using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class up : MonoBehaviour
{
    public Transform mudar;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = mudar.transform.position;
        }

    }
}
