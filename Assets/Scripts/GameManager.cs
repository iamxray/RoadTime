using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    List<GameObject> enemies;

    [SerializeField]

    public GameObject enemiesToPool;

    public int amountToPool = 10;





    Vector3 spawnPoint = new Vector3(25,1,0);

    float  endPointX = -25.0f;

    [SerializeField]
    float secondsStart = 30.0f ;


    [SerializeField]
    float secondsLeft;




    public float SecondsLeft { get { return secondsLeft; } }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemies = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(enemiesToPool);
            tmp.SetActive(false);
            enemies.Add(tmp);
        }

        enemies[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        secondsLeft = secondsStart - Time.timeSinceLevelLoad;

        foreach (GameObject enemy in enemies) 
        {
            
            
            if (enemy.transform.position.x < endPointX)
            {
                enemy.transform.position = spawnPoint;
                enemy.transform.rotation = Quaternion.identity;
                enemy.SetActive(false);
                
            }
        }
        if (!enemies[0].activeInHierarchy) {
            enemies[0].SetActive(true);
        }

        
    }
  
}
