using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Flying Enemy" || collision.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<CapsuleCollider2D>());
        }
    }
}
