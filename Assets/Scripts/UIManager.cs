using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text timer;

    GameManager gameManager;

    string time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

        // Update is called once per frame
        void Update()
    {

        timer.text = "Time: " + (gameManager.SecondsLeft).ToString("0.00");
        
    }
}
