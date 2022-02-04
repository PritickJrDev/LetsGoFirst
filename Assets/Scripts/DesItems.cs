using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesItems : MonoBehaviour
{
    public GameObject hitEffect;
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("PlayerHitPoint"))
        {
            //Debug.Log("collided");
            
            FindObjectOfType<Score>().SetScore(10);
            GameObject clone = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(clone.gameObject, 2f);
            Destroy(gameObject);
        }
    }
}
