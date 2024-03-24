using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Represents an inventory slot
/// Showing the icon of an inventory item and its amount
/// </summary>
public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image icon;
    [SerializeField] private Text label;
    
    /// <summary>
    /// Update the sprite of the inventory slot and the description 
    /// </summary>
    /// <param name="sprite">A Sprite</param>
    /// <param name="count">A number</param>
    public void Draw(Sprite sprite, int count)
    {
        icon.sprite = sprite;
        label.text = count.ToString();
    }

    /// <summary>
    /// If you click it, something probably should happen
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(icon.sprite.name);
    }
}
