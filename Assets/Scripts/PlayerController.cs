using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] AudioClip danoClip;
    [SerializeField] Audio_Controler ac;
    private Vector2 startTouchPos;
    private bool isJumping = false;
    private float jumpForce = 300;
    public float speed = 2f;
    private bool change = false;
    private int bate_count = 0;


    public static PlayerController instance;
    
    void Start()
    {
       _rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        Vector3 dire = new Vector3(1f,0f,0f);
        if (change == true)
        {
            transform.Translate(-dire * Time.deltaTime * speed);
        }
        else
        {

            transform.Translate(dire * Time.deltaTime * speed);
        }

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
                    _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

                }

            }
            
           
        } else if (Input.touchCount > 3){
            
            GameController.instance.CheatVida();
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

        if (other.CompareTag("powe_up"))
        {
            // Power UP
            Destroy(other.gameObject);
            GameController.instance.Power_Up();
        }

        if (other.CompareTag("enemy"))
        {
            // Adicionar Pontos
            Destroy(other.gameObject);
            GameController.instance.AdicionarPontos();
        }

        if (other.CompareTag("Wall"))
        {
            change = true;
            bate_count++;
            if(bate_count == 2)
            {
                change = false;
                bate_count = 0;
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            isJumping = false;
        }

        if (collision.collider.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }
}
