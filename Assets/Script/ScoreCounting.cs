using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounting : MonoBehaviour
{
    public int diamondCount = 0;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        UpdateScoreUI();
    }

    public void AddDiamond(int amount)
    {
        diamondCount += amount;
        UpdateScoreUI();
    }

    public int CalculateFinalScore(float timeLeft)
    {
        int timeBonus = Mathf.FloorToInt(timeLeft * 2); // 1 detik = 2 poin (bisa kamu ubah)
        int diamondScore = diamondCount * 10;           // 1 diamond = 10 poin (bisa kamu ubah)
        return diamondScore + timeBonus;
    }

    public void ResetScore()
    {
        diamondCount = 0;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + (diamondCount * 10);
        }
    }
}
