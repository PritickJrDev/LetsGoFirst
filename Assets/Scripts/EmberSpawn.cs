using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmberSpawn : MonoBehaviour
{
    public GameObject emberEffect;

    void Update()
    {
        GameObject clone = Instantiate(emberEffect, transform.position, Quaternion.identity);
        Destroy(clone.gameObject, 1f);
    }
}
