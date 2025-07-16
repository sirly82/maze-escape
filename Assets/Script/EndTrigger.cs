using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    private void OnTriggerEnter()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "level2")
        {
            AudioManager.Instance.PlayWinMusic();
            Debug.Log("Player sudah di level 2, masuk ke scene WIN");
            SceneManager.LoadScene("win");
        }
        else
        {
            Debug.Log("Lanjut ke level berikutnya");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
