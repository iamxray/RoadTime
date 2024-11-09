using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEditor.SearchService;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text timer;

    [SerializeField]
    TMP_Text highScoreTable;

    [SerializeField]
    TMP_Text score;

    [SerializeField]
    TMP_Text pause;

    [SerializeField]
    TMP_Text gameOver;

    [SerializeField]
    TMP_Text gameWin;

    [SerializeField]
    Button StartButton;

    [SerializeField]
    Button ExitButton;

    [SerializeField]
    Button restartButton;

    [SerializeField]
    Button resumeButton;

    [SerializeField]
    Button menuButton;

    [SerializeField]
    Button nextLevelButton;

    GameManager gameManager;
    ScoreManager scoreManager;


    string time;


    



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        scoreManager = FindAnyObjectByType<ScoreManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene!");
        }



        highScoreTable.text = "High Score: \n" +
            "1. " + scoreManager.hightScoreTable[0].ToString() + "\n" +
            "2. " + scoreManager.hightScoreTable[1].ToString() + "\n" +
            "3. " + scoreManager.hightScoreTable[2].ToString() + "\n" +
            "4. " + scoreManager.hightScoreTable[3].ToString() + "\n" +
            "5. " + scoreManager.hightScoreTable[4].ToString() + "\n" +
            "6. " + scoreManager.hightScoreTable[5].ToString() + "\n" +
            "7. " + scoreManager.hightScoreTable[6].ToString() + "\n" +
            "8. " + scoreManager.hightScoreTable[7].ToString() + "\n" +
            "9. " + scoreManager.hightScoreTable[8].ToString() + "\n" +
            "10. " + scoreManager.hightScoreTable[9].ToString();
    }

        // Update is called once per frame
        void Update()
    {

        timer.text = "Time: " + (gameManager.SecondsLeft).ToString("0.00");
  
        

    }

    public void GamePauseMethod()
    {
        Debug.Log("Pause method");
        if (gameManager.IsGamePaused)
        {
            restartButton.gameObject.SetActive(true);
            resumeButton.gameObject.SetActive(true);
            menuButton.gameObject.SetActive(true);
            pause.gameObject.SetActive(true);
        }
        else
        {
            restartButton.gameObject.SetActive(false);
            resumeButton.gameObject.SetActive(false);
            menuButton.gameObject.SetActive(false);
            pause.gameObject.SetActive(false);
        }

    }

    public void GameOverMethod()
    {
        if (gameManager.IsGameOver)
        {
            restartButton.gameObject.SetActive(true);
            menuButton.gameObject.SetActive(true);
            gameOver.gameObject.SetActive(true);
        }
        else
        {
            restartButton.gameObject.SetActive(false);
            menuButton.gameObject.SetActive(false);
            gameOver.gameObject.SetActive(false);
        }
    }

    public void GameWinMethod()
    {
        if (gameManager.IsGameWin)
        {
            score.text = "Score: " + (gameManager.Score).ToString("0");
            nextLevelButton.gameObject.SetActive(true);
            gameWin.gameObject.SetActive(true);
            
        }
        else
        {
            nextLevelButton.gameObject.SetActive(false);
            gameWin.gameObject.SetActive(false);
            
        }

    }

    public void GameActiveMethod()
    {
        //gameManager.IsGameActive = true;
        restartButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
        pause.gameObject.SetActive(false);
    }

    public void Restart()
    {
        //Scene currScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("Level1");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        
    }
    public void Exit()
    {
        //quit
    }
    public void NextLevel()
    {
        UnityEngine.SceneManagement.Scene scene = SceneManager.GetActiveScene(); ;
        
        int sceneToLoad = scene.buildIndex + 1;

        if (sceneToLoad < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("No next scene available! You are at the last scene.");
        }
    }


}
