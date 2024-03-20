using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Manages the inventory
/// Keeps a dictionary of the inventory items
/// Sends out messages when the inventory changes
/// </summary>
public class InventoryManager : MonoBehaviour
{
    private Dictionary<string, int> data;

    public UnityEvent<Dictionary<string, int>> InventoryUpdated;
    
    /// <summary>
    /// For now, just add some dummy data to the inventory
    /// Quicker to test the UI of the inventory like this.
    /// (after every change of the inventory, make sure the changes are broadcast)
    /// </summary>
    private void Start()
    {
        data = new Dictionary<string, int>()
        {
            { "inv_heart", 10 },
            { "inv_diamond", 15 }
        };
        BroadCastInventoryData();
    }
    
    /// <summary>
    /// Adds a type of item to the inventory.
    /// You also need to specify how many of that type to add
    /// </summary>
    /// <param name="itemName">The type (remember to match the name with a sprite in the resources folder)</param>
    /// <param name="itemCount">The amount to add of said type</param>
    public void AddToInventory(string itemName, int itemCount)
    {
        // logic:
        // if type is not in the inventory yet, add it with said amount
        // otherwise, increase the number of that type
        
        // lastly: broadcast the event that the inventory changed
    }
    
    /// <summary>
    /// Send out the message that the inventory has updated
    /// </summary>
    void BroadCastInventoryData()
    {
        InventoryUpdated?.Invoke(data);
    }
}
