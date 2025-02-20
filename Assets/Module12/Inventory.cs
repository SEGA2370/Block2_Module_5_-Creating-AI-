using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>(); // Now stores Item objects, not strings
    private InventoryUI inventoryUI;

    private void Start()
    {
        inventoryUI = FindObjectOfType<InventoryUI>(true);
    }

    public void AddItem(Item newItem)
    {
        items.Add(newItem);
        Debug.Log($"Picked Up: {newItem.itemName}");

        if (inventoryUI != null && inventoryUI.gameObject.activeInHierarchy)
        {
            inventoryUI.UpdateUI();
        }
    }
}
