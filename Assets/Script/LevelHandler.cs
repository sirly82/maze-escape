using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public void level1()
    {
        AudioManager.Instance.PlayBGM1();
        SceneManager.LoadScene("level1");
    }

    public void exit()
    {
        AudioManager.Instance.PlayBGM3();
        SceneManager.LoadScene("menu");
    }
    public void exitWinLose()
    {
        AudioManager.Instance.PlayBGM3();
        SceneManager.LoadScene("credit");
    }

    public void QuitGame()
    {
        AudioManager.Instance.PlayBGM3();
        Debug.Log("Keluar dari game...");
        Application.Quit();
    }
}
