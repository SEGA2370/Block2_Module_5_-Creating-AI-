using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private Inventory inventory;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    public void PickupItem(Item item)
    {
        inventory.AddItem(item);
    }
}
