using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abumi_Guchi : MonoBehaviour
{

    public float speed = 1f;

    private bool change = false;

    private int bate_count = 0;

    
    [SerializeField] private Animator _animator;

    void Start()
    {
        Destroy(gameObject, 9f);
    }
    void Update()
    {
        
        Vector3 dire = new Vector3(1f,0f,0f);

        _animator.SetFloat("Runnign", dire.magnitude);

        

        if (change == true){
            transform.Translate(dire * Time.deltaTime * speed);
            _animator.SetTrigger("Change");
        } else{

            transform.Translate(-dire * Time.deltaTime * speed);
            _animator.SetTrigger("Combat");
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //madar um sinal quando quando atinjir uma parede
        if(other.CompareTag("Wall")){
            
            change = true;
            if (bate_count == 2)
            {
                change = false;
                bate_count = 0;
            }
        }
        //Se destruir quando o player morrer
        if (other.CompareTag("Player"))
        {
            _animator.SetTrigger("death");
            Destroy(gameObject);

        }

        
    }
}
