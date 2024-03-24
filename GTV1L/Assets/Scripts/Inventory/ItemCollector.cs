using UnityEngine;

/// <summary>
/// The script that checks if the player collided with a pick up and then 
/// </summary>
public class ItemCollector : MonoBehaviour
{
    // The reference to the inventory manager.
    private InventoryManager inventoryManager;
    
    /// <summary>
    /// Initialize the reference to the InventoryManager
    /// </summary>
    void Start()
    {
        // ToDo This script is on the player, so the InventoryManager needs to be found and assigned to the inventoryManager.
        // See book Ch 8, p 224
        inventoryManager = GameObject.FindObjectOfType<InventoryManager>();
        Debug.Log($"Inventory manager: {inventoryManager}");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PickUp>(out PickUp pickup))
        {
            Debug.Log(pickup);
            // if it is a pick up, read the data
            inventoryManager.AddToInventory(pickup.GetInventoryItemID(), pickup.GetItemCount());
            Destroy(other.gameObject);
        }
    }
}
