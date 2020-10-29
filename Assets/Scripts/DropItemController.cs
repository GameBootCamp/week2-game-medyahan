using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemController : MonoBehaviour
{
    [SerializeField] DropItem dropItem;
    private int enemyScore = 20;
    private int goldScore = 50;

    private float speed = 1.5f;
    private float rotationSpeed = 2f;
    private Rigidbody rb;

    private GameObject player;
    private PlayerController playerControl;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        player = GameObject.FindGameObjectWithTag("player");
        playerControl = player.GetComponent<PlayerController>();

        rb.angularVelocity = Random.insideUnitSphere * rotationSpeed;
        rb.velocity = transform.up * -speed;

    }
    private void OnCollisionEnter(Collision col)
    {
        if (dropItem.item.tag == "enemy" && col.gameObject.tag == "player")
        {
            playerControl.GameOver();
            Reset();
            ObjectPooler.Instance.PoolDestroy(dropItem.itemType, this.gameObject);

        }

        if (dropItem.item.tag == "enemy" && col.gameObject.tag == "bullet")
        {
            playerControl.ChangeScore(enemyScore);
            Reset();
            ObjectPooler.Instance.PoolDestroy(dropItem.itemType, this.gameObject);

        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "player")
        {
            playerControl.ChangeScore(goldScore);
            Reset();
            ObjectPooler.Instance.PoolDestroy(dropItem.itemType, this.gameObject);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "area")
        {
            Reset();
            ObjectPooler.Instance.PoolDestroy(dropItem.itemType, this.gameObject);
        }
    }

    public void Reset()
    {

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
