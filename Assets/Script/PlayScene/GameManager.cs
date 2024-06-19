using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TMP_Text scoreText;
    public TMP_Text timeText;

    public float duration = 60f;
    private float timer;
    private int score = 0;
    public bool isGameOver;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        timer = duration;
        score = 0;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            timer -= Time.deltaTime;
            timeText.text = "Time: " + Mathf.FloorToInt(timer).ToString();
            scoreText.text = "Score: " + score.ToString();

            if (timer <= 0)
            {
                isGameOver = true;
                timeText.text = "Time: 0";
                scoreText.text = "Score: " + score;
            }
        }
    }

    public void AddScore(int value)
    {
        score += value;
    }
}
