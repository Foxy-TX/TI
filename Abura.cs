using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abura : MonoBehaviour
{
    public GameObject shield;

    public Transform turret;

    private float _timer = 0f;

    public float shieldCooldown = 0f;

    private bool _canDefend = false;

    private bool _Shield = false;


void Update()
    {//Colldown do Escudo
        _timer += Time.deltaTime;

        if (_timer >= shieldCooldown)
        {
            _canDefend = true;
        }

        if(_Shield == true){
            _timer = 0;
        }

        Protecao(turret.position, turret.rotation);

    }
    public void Protecao(Vector3 posicao, Quaternion rotacao)
    {//Levantar escudo quando o cooldown acabar
        if (_canDefend)
        {
            GameObject clone = Instantiate(shield, posicao, rotacao);
            _canDefend = false;
            _Shield=true;
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
