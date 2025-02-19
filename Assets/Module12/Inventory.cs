using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<string> items = new List<string>();
    private InventoryUI inventoryUI;

    private void Start()
    {
        inventoryUI = FindObjectOfType<InventoryUI>(true);
    }

    public void AddItem(string itemName)
    {
        items.Add(itemName);
        Debug.Log($"Item Picked Up: {itemName}");

        if (inventoryUI != null && inventoryUI.gameObject.activeInHierarchy)
        {
            inventoryUI.UpdateUI();
        }
    }
}
