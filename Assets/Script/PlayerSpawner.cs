using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            player.transform.position = transform.position;
        }
    }
}
