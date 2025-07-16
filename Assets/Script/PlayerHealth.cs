using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;

    public int maxLives = 3;
    private int currentLives;

    public Image[] hearts;
    public TextMeshProUGUI livesText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentLives = GameManager.Instance.playerLives;
        UpdateUI();
    }

    public void TakeDamage(int amount)
    {
        currentLives -= amount;
        GameManager.Instance.playerLives = currentLives;
        Debug.Log("Player kena bom! Sisa nyawa: " + currentLives);
        UpdateUI();

        if (currentLives <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        AudioManager.Instance.PlayLoseMusic();
        Debug.Log("Game Over!");
        SceneManager.LoadScene("lose");
    }

    void UpdateUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (hearts[i] != null)
                hearts[i].enabled = (i < currentLives);
        }

        if (livesText != null)
            livesText.text = currentLives.ToString();
    }

    public void SetUIReferences(Image[] newHearts, TextMeshProUGUI newLivesText)
    {
        hearts = newHearts;
        livesText = newLivesText;
        UpdateUI();
    }

    public void ResetHealth()
    {
        currentLives = maxLives;
        UpdateUI();
    }
}
