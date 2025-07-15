using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamonds : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if(playerInventory != null)
        {
            playerInventory.DiamondCollected();

            ScoreCounting scoreCounting = other.GetComponent<ScoreCounting>();

            if(scoreCounting != null)
            {
                scoreCounting.AddDiamond(1);
            }
            gameObject.SetActive(false);
        }
    }
}
