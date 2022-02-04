using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour
{
    private float moveSpeed;
    public GameObject damageEffect;
    void Start()
    {
        moveSpeed = Random.Range(1f, 3f);
    }
    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * moveSpeed; //moving up
        if (transform.position.y >= -6.30)
        {
            moveSpeed = -Random.Range(1,3); //moving down
           // transform.position += Vector3.down * Time.deltaTime * moveSpeed;
        }

        if (transform.position.y <= -8)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.gameObject.CompareTag("PlayerHitPoint"))
            {
                //audioSource.Play();
                Instantiate(damageEffect, transform.position, Quaternion.identity);
                FindObjectOfType<PlayerHealth>().TakeDamage(1);
                Debug.Log("i hit player");
            }
    }
}
