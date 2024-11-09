using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject finish;

    [SerializeField]
    List<GameObject> spawnPoints;
        
    [SerializeField]
    float secondsStart = 30.0f;

    [SerializeField]
    float secondsLeft;

    [SerializeField]
    bool isPollingLevel = true;

    [SerializeField]
    bool isGameOver = false;

    [SerializeField]
    bool isGameWin = false;

    [SerializeField]
    bool isGameActive = true;

    [SerializeField]
    bool isGamePaused = false;

    [SerializeField]
    bool isMainManu = false;

    private bool isCooldown = false;

    UIManager uiManager;

    ScoreManager scoreManager;

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
        secondsLeft = secondsStart;

        uiManager = FindAnyObjectByType<UIManager>();
        scoreManager = FindAnyObjectByType<ScoreManager>();


        if (uiManager == null)
        {
            Debug.LogError("UIManager not found in the scene!");
        }
        if (uiManager != null)
        {
            Debug.LogError("UIManager  found in the scene!");
        }



        ResumeGame();

    }

    // Update is called once per frame
    void Update()
    {
        if (secondsLeft <= 0)
        {
            GameOver();
        }
        else 
        { 
            secondsLeft = secondsStart - Time.timeSinceLevelLoad; 
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

        if (!isCooldown)
        {
            // Perform the action
            PollEnemies(spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Count)]);

            // Start the cooldown
            StartCoroutine(StartCooldown());
        }

        //if (Input.GetMouseButtonDown(0))
        //{
            

        //}


    }
    private IEnumerator StartCooldown()
    {
        isCooldown = true;

        // Generate a random cooldown time between 1 and 3 seconds
        float cooldownTime = UnityEngine.Random.Range(0.5f, 3f);

        // Wait for the cooldown time
        yield return new WaitForSeconds(cooldownTime);

        // Reset the cooldown
        isCooldown = false;
    }
    void PollEnemies(GameObject pos)
        {
            GameObject enemy = ObjectPooler.SharedInstance.GetPooledObject();
            if (enemy != null)
                {
                    enemy.transform.position = pos.transform.position;
                    enemy.transform.rotation = pos.transform.rotation;
                    enemy.SetActive(true);
                }
        }

        // Method to pause the game
        void PauseGame()
        {
            Debug.Log("Pause");
            isGamePaused = true;
            isGameActive = false;
            uiManager.GamePauseMethod();
            Time.timeScale = 0f; // Stop the game time
        }

        // Method to resume the game
        void ResumeGame()
        {
            Time.timeScale = 1f; // Resume the game time
            Debug.Log("resume game" + uiManager);
            uiManager.GameActiveMethod();
            isGameActive = true;
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
            scoreManager.CheckHighScore(score);

            isGameWin = true;
            isGameActive = false;
            uiManager.GameWinMethod();
            Time.timeScale = 0f;
        }
    

}
