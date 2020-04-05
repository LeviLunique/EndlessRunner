using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;

    public Animator animator;
    private Rigidbody2D rigidbody;

    void Start() 
    {
        if (gameObject.tag == "Enemy" || gameObject.tag == "Flying Enemy") 
        {
            rigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }
    }

    void Update() 
    {

        if (gameObject.tag == "Enemy")
        {
            rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
            animator.SetFloat("Speed", rigidbody.velocity.x);

        }
        else if (gameObject.tag == "Flying Enemy") 
        {
            transform.position += transform.right * speed * Time.deltaTime;
            animator.SetFloat("Speed", speed);
        }
        else if (gameObject.tag == "Platform")
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }

    }

}
