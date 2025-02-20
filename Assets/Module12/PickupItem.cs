using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public Item itemData; // Assign a ScriptableObject item in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
            if (playerInventory != null)
            {
                playerInventory.PickupItem(itemData); // Add the ScriptableObject to inventory
            }
            Destroy(gameObject);
        }
    }
}
