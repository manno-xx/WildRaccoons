using UnityEngine;

/// <summary>
/// A script for the items that can be picked up to be in the inventory
/// Here the sprite defined the type of pick up and the itemCount how many
/// </summary>
public class PickUp : MonoBehaviour
{
    [SerializeField] private Sprite itemType;

    [SerializeField] private int itemCount;

    public string GetInventoryItemID()
    {
        return itemType.name;
    }

    public int GetItemCount()
    {
        return itemCount;
    }
}
