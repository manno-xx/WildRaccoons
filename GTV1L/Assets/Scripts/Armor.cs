using UnityEngine;

/// <summary>
/// The armor on the player
/// When it collides with an armor pick up, it 'applies' its armor value to its own armor
/// The armor value can be accessed by means of a 'getter' for use in damage calculations when being hit
/// </summary>
public class Armor : MonoBehaviour
{
    private float armor = 0;

    public float GetArmorAmount()
    {
        return armor;
    }
    
    /// <summary>
    /// When colliding with something:
    /// - Check if it has the ArmorPickup component
    /// - if so,
    ///     - use its armor value as the current armor value
    ///     - destroy the pickup
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ArmorPickup>(out ArmorPickup armorPickup))
        {
            armor = armorPickup.GetStrength();
            Destroy(other.gameObject);
        }
    }
}
