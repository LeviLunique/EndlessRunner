using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public float speed;

    void Update() 
    {
        transform.position += transform.right * speed * Time.deltaTime;
        //transform.position = new Vector3(transform.position.x + speedX, transform.position.y + speedY);
    }

}
