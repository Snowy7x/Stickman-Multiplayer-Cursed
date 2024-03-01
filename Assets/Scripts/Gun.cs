using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : NetworkClass
{
    public GameObject bullet;
    public Rigidbody2D body;
    public Transform bulletSpawn;
    public float damage = 10f;
    public float fireRate = 15f;
    public float range = 100f;
    public float impactForce = 30f;
    public float recoil = 0.1f;
    
    public bool isAutomatic = false;
    

    void Start()
    {
        
    }

    void Update()
    {
        if (!isMine && !isOffline) return;
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (isAutomatic)
        {
            StartCoroutine(ShootContinuously());
        }
        else
        {
            ShootSingle();
        }
    }
    
    IEnumerator ShootContinuously()
    {
        while (Input.GetButton("Fire1"))
        {
            ShootSingle();
            yield return new WaitForSeconds(1 / fireRate);
        }
    }
    
    void ShootSingle()
    {
        GameObject bulletObj = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        bulletObj.GetComponent<Bullet>().Init(damage, impactForce);
        body.AddForce(-transform.right * recoil, ForceMode2D.Impulse);
    }
}
