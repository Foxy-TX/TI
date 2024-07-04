
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform alvo;

    public float speed = 5;

    public float distancia = 1.0f;

    public bool lvl1;


    // Start is called before the first frame update
    void Start()
    {
        alvo = GameObject.FindGameObjectWithTag("Follow").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = alvo.position - transform.position;

        direction.Normalize();

        transform.Translate(direction * speed * Time.deltaTime);

        if (Vector3.Distance(alvo.position, transform.position) > distancia)
        {
            speed = 20;
        }
        else
        {
            if (lvl1 == true) {
                speed = 3;
            }
            else {
                speed = 5; 
            }
        }
    }
}
