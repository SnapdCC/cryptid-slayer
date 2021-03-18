using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
   public List<GameObject> possibleSpawnPoints = new List<GameObject>();
   public GameObject jackalopePrefab;
   int prevSpawnIndex = -1;


    
    public void SpawnObject()
    {
        int spawnPointIndex;
        do
        {
            spawnPointIndex = Random.Range(0, possibleSpawnPoints.Count);
        } while (prevSpawnIndex == spawnPointIndex && possibleSpawnPoints.Count > 1);
        prevSpawnIndex = spawnPointIndex;
        jackalopePrefab.transform.position = (possibleSpawnPoints[spawnPointIndex].transform.position);
    }


}
