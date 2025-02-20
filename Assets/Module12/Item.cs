using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon; // Image for UI display

    public abstract void Use(); // Polymorphic method
}

[CreateAssetMenu(fileName = "New Wood", menuName = "Items/Wood")]
public class Wood : Item
{
    private void Awake()
    {
        itemName = "Wood";
        itemIcon = Resources.Load<Sprite>("Sprites/wood"); // Correctly loads from Resources
    }

    public override void Use()
    {
        Debug.Log("Using Wood!");
    }
}

[CreateAssetMenu(fileName = "New Iron", menuName = "Items/Iron")]
public class Iron : Item
{
    private void Awake()
    {
        itemName = "Iron";
        itemIcon = Resources.Load<Sprite>("Sprites/iron");
    }

    public override void Use()
    {
        Debug.Log("Using Iron!");
    }
}

[CreateAssetMenu(fileName = "New Axe", menuName = "Items/Axe")]
public class Axe : Item
{
    private void Awake()
    {
        itemName = "Axe";
        itemIcon = Resources.Load<Sprite>("Sprites/axe");
    }

    public override void Use()
    {
        Debug.Log("Chopping with Axe!");
    }
}