using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartTrigger : MonoBehaviour
{
    private void OnTriggerEnter()
    {
        // to restart our same scenes... When we exit in enter direction
        // it will restart the same scene when we get out in start position
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
