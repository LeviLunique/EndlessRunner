using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform firstPlatform;
    public Transform lastPlatform;
    public Transform generationPoint;

    public ObjectPooler objectPool;
    public Vector3 spawnValues;
    public bool actvateRandomSpace = false;

    private float platformWidth;
    private float heightDifference;

    public float distanceBetween;
    public float distanceBetweenMin;
    public float distanceBetweenMax;

    void Start()
    {
        platformWidth = firstPlatform.transform.localScale.x;
        heightDifference = Mathf.Abs(firstPlatform.transform.position.y - lastPlatform.transform.position.y);
    }

    void Update() 
    {
        if (transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y + heightDifference, transform.position.z);

            Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
            GameObject newPlatform = objectPool.GetPooledObject();

            newPlatform.transform.position = spawnPosition;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
        }
    }

}
