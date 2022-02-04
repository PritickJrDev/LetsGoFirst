using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] danItems;
    private int randomSide;
    private Vector3 tempPos;

    void Start()
    {
        StartCoroutine(SpawnDanItems());
    }

    IEnumerator SpawnDanItems()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 3));

            randomSide = Random.Range(1, 3);

            tempPos = transform.position;
            tempPos.x = Random.Range(-22f, 22f);
            tempPos.y = -6.50f;
            transform.position = tempPos;

            if (randomSide == 1)
            {
                Instantiate(danItems[0], transform.position, transform.rotation);
               // Instantiate(danItems[1], transform.position, transform.rotation);
            }

            else if (randomSide == 2)
            {
                GameObject clone = Instantiate(danItems[0], transform.position, transform.rotation);
                clone.transform.localScale = new Vector3(3f, 3f, 3f);
            }
            else
            {
                Debug.Log("No object");
            }

        }
    }
}
