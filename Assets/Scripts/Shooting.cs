using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePointOuter;
    public GameObject bulletPrefab;
    public GameObject trapPrefab;
    public AudioSource gunsound;
    public float bulletForce = 20f;
    float offset = 90f;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
            gunsound.Play();
        }
    }
    
    void Shoot()
    {
        Quaternion angle = Quaternion.Euler(0f, 0f, offset);
        GameObject bullet = Instantiate(bulletPrefab, firePointOuter.position, firePoint.rotation*angle);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet.gameObject, .5f);
    }
    void PlaceTrap()
    {
        Quaternion angle = Quaternion.Euler(0f, 0f, offset);
        GameObject trap = Instantiate(trapPrefab, firePointOuter.position, Quaternion.identity);
        Rigidbody2D rb = trap.GetComponent<Rigidbody2D>();
    }
}
