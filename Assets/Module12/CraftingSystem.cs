using System.Linq;
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
        // Find required items using their class type
        Item wood = inventory.items.FirstOrDefault(item => item is Wood);
        Item iron = inventory.items.FirstOrDefault(item => item is Iron);

        if (wood != null && iron != null)
        {
            inventory.items.Remove(wood);
            inventory.items.Remove(iron);

            // Correct way to create a new ScriptableObject item
            Axe newAxe = ScriptableObject.CreateInstance<Axe>();
            inventory.AddItem(newAxe);

            Debug.Log("Axe is Crafted!");
        }
        else
        {
            Debug.Log("Not Enough Resources");
        }
    }
}
