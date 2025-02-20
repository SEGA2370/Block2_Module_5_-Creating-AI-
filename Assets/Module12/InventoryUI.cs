using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Transform inventoryGrid;
    public GameObject itemSlotPrefab; // Assign in Inspector (Prefab for grid item)

    private Inventory inventory;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        UpdateUI();
    }

    public void UpdateUI()
    {
        // Clear previous slots
        foreach (Transform child in inventoryGrid)
        {
            Destroy(child.gameObject);
        }

        // Add new slots with images
        foreach (Item item in inventory.items)
        {
            GameObject slot = Instantiate(itemSlotPrefab, inventoryGrid);
            Image itemImage = slot.transform.GetChild(0).GetComponent<Image>(); // Get image component
            if (item.itemIcon != null)
            {
                itemImage.sprite = item.itemIcon; // Assign the correct sprite
            }
        }
    }
}
