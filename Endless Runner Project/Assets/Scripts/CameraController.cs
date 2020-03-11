using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    /*
    void Update() 
    {
        if (target.position.y > transform.position.y) 
        {
            transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
        } else
        {

            Vector3 newPos = target.position + offset;
            newPos.z = transform.position.z;
            newPos.y = transform.position.y;
            transform.position = newPos;
        }
    }
    */
    void LateUpdate()
    {

        Vector3 newPos = target.position + offset;
        newPos.z = transform.position.z;
        //newPos.y = target.position.y - 0.3f;

        transform.position = newPos;
    }
    

}
