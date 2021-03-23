using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    SpriteRenderer gun;
    public Transform firePoint;
    // public Transform firePointOuter;
    public GameObject bulletPrefab;
    public GameObject trapPrefab;
    // public GameObject trapPrefab;
    public AudioSource gunsound;
    public float bulletForce = 20f;
    float offset = 0f;
    void Start()
    {
        gun = transform.GetComponentInChildren<SpriteRenderer>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
        // Debug.Log(transform.rotation.z);
        if((Mathf.Abs(transform.rotation.z)> .71f) && gun.flipY == false){
            Debug.Log("Flip");
            gun.flipY = true;
        } 
        else if(Mathf.Abs(transform.rotation.z)< .71f && gun.flipY == true){
            Debug.Log("Flip");
            gun.flipY = false;
        }
        
    }
    void Update()
    {
        if(Time.timeScale>0){
            if(Input.GetKeyDown(KeyCode.E))
            {
                Shoot();
                gunsound.Play();
            }
            if(Input.GetKeyDown(KeyCode.R)){
                if(Pickup.trappickupcount == 1)
                {
                    PlaceTrap();
                }
                
            }
        }
    }
    void Shoot()
    {
        Quaternion angle = Quaternion.Euler(0f, 0f, offset);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation*angle);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet.gameObject, .5f);
    }
    void PlaceTrap(){
        GameObject trap = Instantiate(trapPrefab, transform.position, Quaternion.identity);
    }
}
