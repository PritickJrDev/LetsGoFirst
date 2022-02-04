using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] desItems;
    private int randomSide;
    private Vector3 tempPos;
    private LevelMenu itemSpeed;
    public GameObject spawnEffect;
    void Start()
    {
        StartCoroutine(SpawnDesItems());
        itemSpeed = GameObject.FindGameObjectWithTag("LevelMenu").GetComponent<LevelMenu>();
    }

    IEnumerator SpawnDesItems()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(3, 5));

            randomSide = Random.Range(1, 3);
 
            tempPos = transform.position;
            tempPos.x = Random.Range(-25f, 25f);
            tempPos.y = -6.50f;
            transform.position = tempPos;
          
            if(randomSide == 1)
            {
                GameObject clone = Instantiate(desItems[0], transform.position, transform.rotation);
                Instantiate(spawnEffect, transform.position, Quaternion.identity);

                if (clone != null && itemSpeed.speedUpItemSpawn)
                {
                    Destroy(clone.gameObject, 3f);
                }
                
                if (clone != null)
                {
                    Destroy(clone.gameObject, 5f);
                }
            }

            else if(randomSide == 2)
            {
                GameObject clone = Instantiate(desItems[1], transform.position, transform.rotation);
                Instantiate(spawnEffect, transform.position, Quaternion.identity);

                if (clone != null && itemSpeed.speedUpItemSpawn)
                {
                    Destroy(clone.gameObject, 3f);
                }

                if (clone != null)
                {
                    Destroy(clone.gameObject, 5f);
                }
            }
            else
            {
                Debug.Log("No object");

            }

        }
    }
}
