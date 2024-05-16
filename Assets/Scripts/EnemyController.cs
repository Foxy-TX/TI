using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Transform alvo;

    public Transform turret;

    private float _timer = 0f;

    public float shootCooldown = 0f;

    public float speed = 5;

    private bool _canshoot = false;




    void Start()
    {
        //Definir o alvo do enimigo
        alvo = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {//Colldown do tiro
        _timer += Time.deltaTime;

        if (_timer >= shootCooldown)
        {
            _canshoot = true;
        }
        //Fazer o enimigo perseguir o player
        //Vector3 direction = alvo.position - transform.position;

        //direction.Normalize();

        //transform.Translate(direction * speed * Time.deltaTime, Space.World);
        //Atirar
        ShootControl(turret.position, turret.rotation);
    }

    public void ShootControl(Vector3 posicao, Quaternion rotacao)
    {//Atirar quando o cooldown acabar
        if (_canshoot)
        {
            GameObject clone = Instantiate(bulletPrefab, posicao, rotacao);
            Bullet bulletScript = clone.GetComponent<Bullet>();
            _canshoot = false;
            _timer = 0f;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        //Se destruir quando o player morrer
        if (other.CompareTag("Player"))
        {

            Destroy(gameObject);

        }
    }
}
