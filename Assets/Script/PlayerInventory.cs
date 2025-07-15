using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;
    public int NumberOfDiamonds {get; private set; }

    public UnityEvent<PlayerInventory> OnDiamondCollected;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DiamondCollected()
    {
        NumberOfDiamonds++;
        OnDiamondCollected.Invoke(this);

        GameManager.Instance.AddDiamond(1);
        GameManager.Instance.AddScore(10);
    }

    public void ResetDiamonds()
    {
        NumberOfDiamonds = 0;
        OnDiamondCollected.Invoke(this);
    }
}
