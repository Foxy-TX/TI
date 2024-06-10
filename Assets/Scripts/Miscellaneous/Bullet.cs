using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;
    public float velocity;

    void Update()
    {
        transform.Translate(direction * velocity * Time.deltaTime);     
    }
}
