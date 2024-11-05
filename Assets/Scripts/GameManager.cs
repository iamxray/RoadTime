using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject finish;

    List<GameObject> enemies;

    [SerializeField]
    GameObject enemiesToPool;

    [SerializeField]
    int amountToPool = 10;

    Vector3 spawnPoint = new Vector3(25, 1, 0);

    float endPointX = -25.0f;

    [SerializeField]
    float secondsStart = 30.0f;

    [SerializeField]
    float secondsLeft;

    [SerializeField]
    bool isGameOver = false;

    [SerializeField]
    bool isGameWin = false;

    [SerializeField]
    bool isGameActive = true;

    [SerializeField]
    bool isGamePaused = false;

    UIManager uiManager;


    float score;

    // ENCAPSULATION and ABSTRACTION of Timer
    public float SecondsLeft { get { return secondsLeft; } }

    public bool IsGameOver { get { return isGameOver; } }
    public bool IsGameWin { get { return isGameWin; } }

    public bool IsGamePaused { get { return isGamePaused; } }

    public bool IsGameActive { get { return isGameActive; } set { isGameActive = value; } }

    public float Score { get { return score; } }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isGameActive = true;

        //Pooling
        enemies = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(enemiesToPool);
            tmp.SetActive(false);
            enemies.Add(tmp);
        }

        //Test enemy start
        enemies[0].SetActive(true);

        uiManager = FindAnyObjectByType<UIManager>();


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
        if (!enemies[0].activeInHierarchy)
        {
            enemies[0].SetActive(true);
        }





        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        if (isGameActive)
        {
            ResumeGame();
        }


    }
    // Method to pause the game
    void PauseGame()
    {
        
        isGamePaused = true;
        isGameActive = false;
        uiManager.GamePauseMethod();
        Time.timeScale = 0f; // Stop the game time
    }

    // Method to resume the game
    void ResumeGame()
    {
        Time.timeScale = 1f; // Resume the game time
        uiManager.GameActiveMethod();
        
        isGamePaused = false;
        isGameOver = false;
        isGameWin = false;
    }

    public void GameOver()
    {
        
        isGameOver = true;
        isGameActive = false;
        uiManager.GameOverMethod();
        Time.timeScale = 0f;

    }

    public void GameWin()
    {
        score = secondsLeft;
        isGameWin = true;
        isGameActive = false;
        uiManager.GameWinMethod();
        Time.timeScale = 0f;
    }


}
