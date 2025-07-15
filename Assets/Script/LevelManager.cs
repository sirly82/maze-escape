using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Image[] hearts;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        // Update referensi UI untuk PlayerHealth
        if (PlayerHealth.Instance != null)
        {
            PlayerHealth.Instance.SetUIReferences(hearts, livesText);
        }

        // Update referensi UI untuk ScoreCounting
        if (ScoreCounting.Instance != null)
        {
            ScoreCounting.Instance.SetScoreText(scoreText);
        }
    }

    public void LoadNextLevel(string nextSceneName)
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
