using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounting : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static ScoreCounting Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreUI();
    }

    public void AddDiamond(int amount)
    {
        UpdateScoreUI();
    }

    public void ResetScore()
    {
        UpdateScoreUI();
    }

    public void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + GameManager.Instance.totalScore;
        }
    }

    public void SetScoreText(TextMeshProUGUI newScoreText)
    {
        scoreText = newScoreText;
        UpdateScoreUI();
    }
}
