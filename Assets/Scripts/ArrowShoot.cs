using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject arrowPrefab;
    //public AudioSource gunsound;
    public float arrowForce = 20f;

    // Update is called once per frame
    void Update()
    {

        //Shoot();
        
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * arrowForce, ForceMode2D.Impulse);
        Destroy(arrowPrefab.gameObject, .5f);
    }
}
