using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3;
    private int currentLives;

    public Image[] hearts;

    public TextMeshProUGUI livesText;

    // Start is called before the first frame update
    void Start()
    {
        currentLives = maxLives;
        UpdateUI();
    }

    public void TakeDamage(int amount)
    {
        currentLives -= amount;
        Debug.Log("Player kena bom! Sisa nyawa: " + currentLives);
        UpdateUI();

        if (currentLives <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Game Over!");
        SceneManager.LoadScene("lose");
    }

    void UpdateUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = (i < currentLives);
        }
    }
}
