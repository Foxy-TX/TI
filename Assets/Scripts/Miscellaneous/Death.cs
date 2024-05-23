using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject btn_tryAgain;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            btn_tryAgain.SetActive(true);
        }
    }
}
