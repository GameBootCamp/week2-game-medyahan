using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody rb;
    private float speed = 15;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.velocity = transform.up * speed;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "enemy")
            Destroy(this.gameObject);
    }

}
