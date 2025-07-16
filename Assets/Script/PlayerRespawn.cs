using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerRespawn : MonoBehaviour
{
    public Transform spawnPoint; // <-- ini bisa kamu drag dari Inspector
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        if (spawnPoint != null)
        {
            Debug.Log("SpawnPoint ditentukan: " + spawnPoint.position);
        }
        else
        {
            spawnPoint = transform; // fallback ke posisi saat ini
            Debug.LogWarning("⚠️ SpawnPoint belum diset di Inspector, pakai posisi sekarang.");
        }
    }

    public void RespawnToStart()
    {
        Debug.Log("Player kembali ke posisi spawnPoint: " + spawnPoint.position);

        if (controller != null)
            controller.enabled = false;

        transform.position = spawnPoint.position;

        if (controller != null)
            controller.enabled = true;
    }
}