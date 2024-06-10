using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float jumpForce = 50f;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rb;


    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0f, v);
        _animator.SetFloat("Runnign", dir.magnitude);
        transform.Translate(dir * moveSpeed * Time.deltaTime, Space.World);

        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger("attack");
        }



        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            _animator.SetTrigger("jump");
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            _animator.SetTrigger("hit");
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            _animator.SetTrigger("death");
        }

    }

    public void DebugAnimationEvent()
    {
        Debug.Log("Alo mundo");
    }
}
