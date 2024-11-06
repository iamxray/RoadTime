using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;

    List<GameObject> enemies;

    [SerializeField]
    GameObject enemiesToPool;

    [SerializeField]
    int amountToPool = 10;

    //float endPointX = -25.0f;

    //Vector3 spawnPoint = new Vector3(25, 1, 0);

    void Awake()
    {
        SharedInstance = this;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Pooling
        enemies = new List<GameObject>();

        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(enemiesToPool);
            tmp.SetActive(false);
            enemies.Add(tmp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //foreach (GameObject enemy in enemies)
        //{


        //    if (enemy.transform.position.x < endPointX)
        //    {
        //        enemy.transform.position = spawnPoint;
        //        enemy.transform.rotation = Quaternion.identity;
        //        enemy.SetActive(false);

        //    }
        //}

       
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!enemies[i].activeInHierarchy)
            {
                return enemies[i];
            }
        }
        return null;
    }
}
