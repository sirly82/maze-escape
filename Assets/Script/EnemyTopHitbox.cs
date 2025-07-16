using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTopHitbox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Kena dari atas! Musuh mati!");

            AudioManager.Instance.PlayEnemyDeath();
            Destroy(transform.parent.gameObject);

            // Tambah skor +50
            GameManager.Instance.AddScore(50);
            ScoreCounting.Instance.UpdateScoreUI();

            // Cegah trigger lain ikut eksekusi
            EnemyController controller = GetComponentInParent<EnemyController>();
            if (controller != null)
            {
                controller.hasBeenKilled = true;
            }

            Destroy(transform.parent.gameObject); // Hancurkan musuh
        }
    }
}
