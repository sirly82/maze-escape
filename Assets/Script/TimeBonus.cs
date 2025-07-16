using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBonus : MonoBehaviour
{
    public float timeToAdd = 10f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CountdownTimer timer = FindObjectOfType<CountdownTimer>();
            if (timer != null)
            {
                timer.AddTime(timeToAdd);
            }

            AudioManager.Instance.PlayTimeBonus();
            Destroy(gameObject);
        }
    }
}
