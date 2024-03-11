using UnityEngine;

/// <summary>
/// The pickup of armour. Defines an amount of armour and defines a 'getter' for the value
/// (the 'getter' can be implemented as a C# Property)
/// </summary>
public class ArmorPickup : MonoBehaviour
{
    [SerializeField] private float strength = 10;
    
    /// <summary>
    /// Returns the strength of this armor pickup
    /// </summary>
    /// <returns></returns>
    public float GetStrength()
    {
        return strength;
    }
}
