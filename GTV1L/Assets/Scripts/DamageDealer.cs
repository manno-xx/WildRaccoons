using UnityEngine;

/// <summary>
/// The dealer of damage. Defines an amount of damage and defines a 'getter' for the value
/// (the 'getter' can be implemented as a C# Property)
/// </summary>
public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float amount = 10;
    
    /// <summary>
    /// Get the amount of damage being done by this
    /// </summary>
    /// <returns>The amount of damage</returns>
    public float GetAmount()
    {
        return amount;
    }
}
