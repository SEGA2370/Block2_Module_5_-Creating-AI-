using UnityEngine;

public class CraftingSystem : MonoBehaviour
{
    private Inventory inventory;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    public void CraftAxe()
    {
        if (inventory.items.Contains("Wood") && inventory.items.Contains("Iron"))
        {
            inventory.items.Remove("Wood");
            inventory.items.Remove("Iron");
            inventory.items.Add("Axe");

            Debug.Log("Axe is Crafted!");
            FindObjectOfType<InventoryUI>().UpdateUI(); // Обновляем UI
        }
        else
        {
            Debug.Log("Not Enough Resources");
        }
    }
}
