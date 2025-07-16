using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int totalScore = 0;
    public int diamondCount = 0;
    public int playerLives = 3;

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

    public void AddScore(int amount)
    {
        totalScore += amount;
    }

    public void AddDiamond(int amount)
    {
        diamondCount += amount;
    }

    public void ResetAll()
    {
        totalScore = 0;
        diamondCount = 0;
    }

    public void DecreaseScore(int amount)
    {
        totalScore -= amount;
        totalScore = Mathf.Max(0, totalScore); // Pastikan score tidak kurang dari 0
        ScoreCounting.Instance.UpdateScoreUI();
    }
}
