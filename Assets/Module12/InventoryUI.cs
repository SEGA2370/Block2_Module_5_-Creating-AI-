using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public TextMeshProUGUI inventoryText;
    private Inventory inventory;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        UpdateUI();
    }

    public void UpdateUI()
    {
        inventoryText.text = "Inventory:\n";
        foreach (var item in inventory.items)
        {
            inventoryText.text += "- " + item + "\n";
        }
    }
}
