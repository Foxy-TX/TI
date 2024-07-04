using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public GameObject bulletPrefab;

    public GameObject powerUpPrefab;

    public Transform alvo;

    public Transform turret;

    private float _timer = 0f;

    public float shootCooldown = 0f;

    public float speed = 5;

    public float distancia = 4.0f;

    private bool _canshoot = false;

    private float aleatorio;

    


   
    void Start()
    {
        //Definir o alvo do enimigo
        alvo = GameObject.FindGameObjectWithTag("Player").transform;
        aleatorio = Random.value;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        //Fazer o enimigo perseguir o player
        Vector3 direction = alvo.position - transform.position;
        direction.y = 0f;

        direction.Normalize();

        if (_timer >= shootCooldown)
        {

            if (Vector3.Distance(alvo.position, transform.position) < distancia)
            {
                _canshoot = true;
            }
            else
            {
                _canshoot = false;
            }
        }

        transform.Translate(direction * speed * Time.deltaTime, Space.World);
        //Atirar
        ShootControl(turret.position, turret.rotation);
    }

    public void ShootControl(Vector3 posicao, Quaternion rotacao)
    {//Atirar quando o cooldown acabar
        if (_canshoot)
        {
            _animator.SetTrigger("Combat");
            GameObject clone = Instantiate(bulletPrefab, posicao, rotacao);
            Bullet bulletScript = clone.GetComponent<Bullet>();
            _canshoot = false;
            _timer = 0f;
        }


    }

    public void PowerUpControl(Vector3 posicao, Quaternion rotacao)
    {//Atirar quando o cooldown acabar
        if (_canshoot)
        {
            GameObject clone = Instantiate(powerUpPrefab, posicao, rotacao);
        }



    }
    private void OnTriggerEnter(Collider other)
    {
        //Se destruir quando o player morrer
        if (other.CompareTag("Player"))
        {
            _animator.SetTrigger("death");
            Destroy(gameObject);
            if (aleatorio >= 0.3f)
            {
               PowerUpControl(turret.position, turret.rotation);
            }

        }
    }
}
