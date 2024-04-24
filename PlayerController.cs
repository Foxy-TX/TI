using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] AudioClip danoClip;
    [SerializeField] Audio_Controler ac;
    private Vector2 startTouchPos;
    //private Rigidbody rb;
    private bool isJumping = false;
    private float jumpForce = 300;
    public static PlayerController instance;
    
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startTouchPos = touch.position;              
            }
           else if (touch.phase == TouchPhase.Moved)
            {              
                if (!isJumping && Mathf.Abs(touch.position.y - startTouchPos.y) > 100)
                {
                    isJumping = true;
                   // Vector3 jumpDirection = (touch.position - startTouchPos).normalized;
                   // jumpDirection.y = 0.5f;
                    //rb.AddForce(jumpDirection * jumpForce, ForceMode.Impulse);
                   GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

                }
              
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {

    if (other.CompareTag("Enemy_Shield"))
        {
            //Tomar Dano
            ac.audioSFX(danoClip);
            GameController.instance.GameOver();
        }

    if (other.CompareTag("Enemy_bullet"))
        {
            //Tomar Dano
            ac.audioSFX(danoClip);
            Destroy(other.gameObject);
            GameController.instance.GameOver();
        }
        

        if (other.CompareTag("coin"))
        {
            // Adicionar Pontos
            Destroy(other.gameObject);
            GameController.instance.AdicionarPontos();
        }

        if (other.CompareTag("enemy"))
        {
            // Adicionar Pontos
            Destroy(other.gameObject);
            GameController.instance.AdicionarPontos();
        }

    
    
    }
}
