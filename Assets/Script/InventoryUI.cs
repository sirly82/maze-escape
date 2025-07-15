using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI diamondText;

    // Start is called before the first frame update
    void Start()
    {
        diamondText = GetComponent<TextMeshProUGUI>();

        if (PlayerInventory.Instance != null)
        {
            UpdateDiamondText(PlayerInventory.Instance);
            PlayerInventory.Instance.OnDiamondCollected.AddListener(UpdateDiamondText);
        }
    }

    public void UpdateDiamondText(PlayerInventory playerInventory)
    {
        diamondText.text = playerInventory.NumberOfDiamonds.ToString();
    }
}
