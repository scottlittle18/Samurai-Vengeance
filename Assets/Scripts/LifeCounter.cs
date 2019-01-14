﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeCounter : MonoBehaviour {

    [SerializeField]
    [Tooltip("The Number of Lives That the Player Starts the Game with")]
    private int playerLives;
    private int lifeCounter;
    //[SerializeField]
    private Text lifeText;
    private bool gameOver;
    private int levelToRetry;

    #region Properties
    public bool GameOver
    {
        get
        {
            return gameOver;
        }
        set
        {
            gameOver = value;
            CheckForGameOver();
        }
    }

    public int LifeCountKeeper
    {
        get
        {
            return PlayerPrefs.GetInt("LifeCounter");
        }
        set
        {
            PlayerPrefs.SetInt("LifeCounter", value);
            SetLifeCounterText();
        }
    }

    public int LevelToRetry
    {
        get
        {
            return levelToRetry;
        }
        set
        {
            levelToRetry = value;
        }
    }
    #endregion

    private void Awake()
    {
        lifeText = GetComponent<Text>();
        LifeCountKeeper = playerLives;
    }

    private void Start()
    {
        GameOver = false;
    }

    private void CheckForGameOver()
    {
        if (GameOver == true)
        {
            //levelToRetry = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("LevelToRetry", SceneManager.GetActiveScene().buildIndex);
            //TODO: Debug.Log("Scene to be retried is " + LevelToRetry);
            Debug.Log("Scene to be retried is " + PlayerPrefs.GetInt("LevelToRetry"));
            SceneManager.LoadScene("Game Over");
            //TODO: Debug.Log("Game Should Be Over");
            Debug.Log("Game Should Be Over");
        }
    }

    private void SetLifeCounterText()
    {
        lifeText.text = "x" + LifeCountKeeper.ToString();
        //TODO: Debug.Log("LifeCounterTextSet");
        Debug.Log("LifeCounterTextSet");
        if (LifeCountKeeper < 0)
            GameOver = true;
    }

    public void ResetLifeCount()
    {
        LifeCountKeeper = playerLives;
    }
}
