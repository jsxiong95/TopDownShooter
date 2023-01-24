using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] public Transform firePoint;
    [SerializeField] public GameObject bulletPrefab;

    [SerializeField] public float bulletForce = 20f;

    // Update is called once per frame
    void Update() {
        if(Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    // Shoots the bullet from the anchor point
    void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
