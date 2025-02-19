using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public string itemName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
            if (playerInventory != null)
            {
                playerInventory.PickupItem(itemName);
            }
            else
            {
                Debug.LogError("PlayerInventory Not Found");
            }
            Destroy(gameObject);
        }
    }
}
