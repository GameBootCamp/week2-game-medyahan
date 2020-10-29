using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    float fireTime = 0;
    private float fireTimePeriod = 0.15f; // Ateş etme zaman aralığı
    public GameObject bullet;
    [SerializeField] private Transform bulletLocation;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > fireTime)
        {
            fireTime = Time.time + fireTimePeriod;
            
            Instantiate(bullet, bulletLocation.position, bulletLocation.rotation); // Lazerin çıkış yerini belirleme
            
        }
    }
}
