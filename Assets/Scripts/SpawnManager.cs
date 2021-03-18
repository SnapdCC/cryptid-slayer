using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
   public List<GameObject> possibleSpawnPoints = new List<GameObject>();
   public GameObject jackalopePrefab;
   private int chosenSpawnPoint;
   private int prevSpawnPoint;





    void Update()
    {
        if (ChangePositionTrigger.activatetrigger == true)
        {
            newspawn();
        }
    }

    public void newspawn()
    {
        
        if (prevSpawnPoint == chosenSpawnPoint && possibleSpawnPoints.Count > 1)
        {
            prevSpawnPoint = chosenSpawnPoint;
            chosenSpawnPoint = Random.Range(0, possibleSpawnPoints.Count);
            jackalopePrefab.transform.position = (possibleSpawnPoints[chosenSpawnPoint].transform.position);

        }
        if (prevSpawnPoint != chosenSpawnPoint)
        {
            chosenSpawnPoint = Random.Range(0, possibleSpawnPoints.Count);
            jackalopePrefab.transform.position = (possibleSpawnPoints[chosenSpawnPoint].transform.position);
        }
        
    }
         
     
}
