using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            Debug.Log("Player ditemukan, dipindahkan ke spawn point!");
            player.transform.position = transform.position;
        }
        else
        {
            Debug.LogWarning("Player tidak ditemukan di scene.");
        }
    }
}
