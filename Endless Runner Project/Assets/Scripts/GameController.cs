using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public ObjectPooler[] objectPools;
    public Vector3 spawnValues;
    public int hazardCount;
    public float maxDistanceY;
    public float minDistanceY;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    void Start()
    {
        StartCoroutine (SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
                if (gameObject.tag == "Flying Enemy Controller") 
                {
                    spawnPosition = new Vector3(spawnValues.x, Random.Range(minDistanceY, maxDistanceY), spawnValues.z);
                }

                GameObject newObject = objectPools[Random.Range(0, objectPools.Length)].GetPooledObject();

                newObject.transform.position = spawnPosition;
                newObject.transform.rotation = transform.rotation;
                newObject.SetActive(true);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }

    }

}
