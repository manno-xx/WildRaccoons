using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Create / show the UI for the Inventory
/// For now in a separate Canvas (to not have to bother with accidentally moving the health bar)
/// </summary>
public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private InventorySlot slot;

    /// <summary>
    /// Updates the HUD/UI to show whats in the inventory
    /// </summary>
    /// <param name="inventory">the actual data of the inventory</param>
    public void UpdateDisplay(Dictionary<string, int> inventory)
    {
        ClearUI();
        
        foreach (KeyValuePair<string,int> invItem in inventory)
        {
            InventorySlot newSlot = Instantiate(slot, transform);
            newSlot.Draw(Resources.Load<Sprite>(invItem.Key), invItem.Value);
        }
    }

    /// <summary>
    /// This clears any previously shown inventory items. As to start with a clean slate before drawing a new status.
    /// Done for you because of some, imo, peculiar dealing with removing objects from the hierarchy.
    /// 
    /// </summary>
    private void ClearUI()
    {
        // loop as many times that there are children
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
