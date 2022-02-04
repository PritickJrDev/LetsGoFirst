using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health=4;

    public Color myColor;

    public SpriteRenderer sr;
    AudioSource audioSource;
    public AudioClip otherClip;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (health == 1)
        {
            myColor = new Color(1, 0, 0, 1); //Red color
            sr.material.color = myColor;
        }
        if (health == 2)
        {
            myColor = new Color(1, (float)0.5240722, 0, 1); //Orange
            sr.material.color = myColor;
        }
        if (health == 3)
        {
            myColor = new Color(1, (float)0.92, (float)0.016, 1); //Yellow
            sr.material.color = myColor;
        }
        if(health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Gameplay");
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        audioSource.PlayOneShot(otherClip);
    }
}
