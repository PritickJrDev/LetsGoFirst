using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    Rigidbody2D rb;

    private float movementX;
    private float movementY;
    public float moveSpeed = 100f;
    public float jumpForce = 10f;
    public GameObject groundEffect;
    public Transform effectPoint;
    AudioSource audioSource;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");
        
    }

    void FixedUpdate()
    {

        //rb.velocity += new Vector2(movementX, movementY).normalized * moveSpeed * Time.fixedDeltaTime; //for top down movement
     
        rb.velocity += new Vector2(movementX, -1f) * moveSpeed * Time.fixedDeltaTime;
       // rb.AddForce(new Vector2(movementX, 0f) * moveSpeed, ForceMode2D.Force);
       
        //if(Input.GetButtonDown("Jump"))
        //{
        //    rb.velocity = Vector2.up * jumpForce;
        //}
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            Instantiate(groundEffect, effectPoint.position, Quaternion.identity);
            audioSource.Play();
        }
    }
}
