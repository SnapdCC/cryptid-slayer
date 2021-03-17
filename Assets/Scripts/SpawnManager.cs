using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
   public List<GameObject> possibleSpawnPoints = new List<GameObject>();
   public GameObject jackalopePrefab;
   private int chosenSpawnPoint;





    void Update()
    {
        if (ChangePositionTrigger.activatetrigger == true)
        {
            newspawn();
        }
    }

    public void newspawn()
    {
        jackalopePrefab.transform.position = (possibleSpawnPoints[chosenSpawnPoint].transform.position);
        chosenSpawnPoint = Random.Range(0, possibleSpawnPoints.Count);
    }
         
     
}
