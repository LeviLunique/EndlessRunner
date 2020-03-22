using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Controller2D))]
public class InvisibleObject : MonoBehaviour
{
    private Player player;

    public float maxJumpHeight = 4;
    public float minJumpHeight = 1;
    public float timeToJumpApex = .4f;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;

    public float moveSpeed;

    private Animator animator;

    public Vector2 wallJumpClimb;
    public Vector2 wallJumpOff;
    public Vector2 wallLeap;

    public float wallSlideSpeedMax = 3;
    public float wallStickTime = .25f;
    float timeToWallUnstick;

    float gravity;
    float maxJumpVelocity;
    float minJumpVelocity;
    Vector3 velocity;
    float velocityXSmoothing;

    public Controller2D controller;

    Vector2 directionalInput;
    bool wallSliding;
    int wallDirX;

    void Start()
    {

        controller = GetComponent<Controller2D>();

        player = GameObject.Find("Player").GetComponent<Player>();
        moveSpeed = player.moveSpeed;

        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);


    }

    void Update()
    {
        moveSpeed = player.moveSpeed;
        CalculateVelocity();
        HandleWallSliding();

        /*
        if (transform.position.x > player.transform.position.x || transform.position.x < player.transform.position.x) 
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        }
        
        

        
        if (controller.collisions.above || controller.collisions.below)
        {
            if (controller.collisions.slidingDownMaxSlope)
            {
                velocity.y += controller.collisions.slopeNormal.y * -gravity * Time.deltaTime;
            }
            else
            {
                velocity.y = 0;
            }

        }

        */

        controller.Move(velocity * Time.deltaTime, directionalInput);


    }

    public void SetDirectionalInput(Vector2 input)
    {
        directionalInput = input;
    }

    public void OnJumpInputDown()
    {
        
    }

    public void OnJumpInputUp()
    {
        
    }

    void HandleWallSliding()
    {
        wallDirX = (controller.collisions.left) ? -1 : 1;
        wallSliding = false;
        if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0)
        {
            wallSliding = true;

            if (velocity.y < -wallSlideSpeedMax)
            {
                velocity.y = -wallSlideSpeedMax;
            }

            if (timeToWallUnstick > 0)
            {
                velocityXSmoothing = 0;
                velocity.x = 0;

                if (directionalInput.x != wallDirX && directionalInput.x != 0)
                {
                    timeToWallUnstick -= Time.deltaTime;
                }
                else
                {
                    timeToWallUnstick = wallStickTime;
                }

            }
            else
            {
                timeToWallUnstick = wallStickTime;
            }
        }
    }

    void CalculateVelocity()
    {
        //float targetVelocityX = directionalInput.x * moveSpeed;
        float targetVelocityX = 0;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;
    }


    /*
    public float moveSpeed = 6.0f;
    public float verticalSpeed = 0.1f;

    private Rigidbody2D objectRigidbody;

    void Start()
    {
        objectRigidbody = GetComponent <Rigidbody2D> ();
    }

    void Update()
    {

         objectRigidbody.velocity = new Vector2(moveSpeed, objectRigidbody.velocity.y);

         //transform.position += transform.right * moveSpeed * Time.deltaTime;
         //transform.position += transform.up * verticalSpeed * Time.deltaTime;

         //transform.Translate((moveSpeed * Time.deltaTime), Time.deltaTime, 0);

    }
    */

 }
