using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    Player player;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        player.SetDirectionalInput(directionalInput);

        if (Input.GetKeyDown (KeyCode.UpArrow)) 
        {
            player.OnJumpInputDown();
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            player.OnJumpInputUp();
        }

        if (Time.time >= nextAttackTime) 
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
}
