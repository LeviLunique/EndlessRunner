using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public Transform firstPlatform;
    public Transform lastPlatform;
    public Transform generationPoint;
    public float distanceBetween;

    private float platformWidth;
    private float heightDifference;

    public bool actvateRandomSpace = false;
    public float distanceBetweenMin;
    public float distanceBetweenMax;

    public ObjectPooler objectPool;

    void Start()
    {
        platformWidth = firstPlatform.transform.localScale.x;
        heightDifference = Mathf.Abs(firstPlatform.transform.position.y - lastPlatform.transform.position.y);
    }

    void Update()
    {

        if (transform.position.x < generationPoint.position.x) 
        {
            if (actvateRandomSpace) 
            {
                distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            }
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y + heightDifference, transform.position.z);

            //transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);

            //Instantiate(platformPrefab, transform.position, transform.rotation);

            GameObject newPlatform = objectPool.GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
        }
    }
}
