using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public float startTime = 60f;
    private float currentTime;

    public TMP_Text timerText;

    public bool isTimeRunning = true;
    private bool hasGameOverTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
        UpdateTimerDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimeRunning)
        {
            currentTime -= Time.deltaTime;
            currentTime = Mathf.Max(currentTime, 0f);
            UpdateTimerDisplay();

            if (currentTime <= 0f && !hasGameOverTriggered)
            {
                isTimeRunning = false;
                hasGameOverTriggered = true;
                GameOver();
            }
        }
    }

    public void AddTime(float amount)
    {
        currentTime += amount;
        UpdateTimerDisplay();
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void GameOver()
    {
        Debug.Log("Waktu habis! Game Over!");
        SceneManager.LoadScene("lose");
    }
}
