using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines a health system
/// </summary>
public class Health : MonoBehaviour
{
    // the health (current and max) values
    [Header("health settings")] // this makes the inspector look a bit more organized.
    private float CurrentHealth = 0;
    private float MaxHealth = 100; // Should you be able to change the value of this in the inspector? Probably...
    
    /// <summary>
    /// Make sure the player start at max health
    /// </summary>
    void Start()
    {
        CurrentHealth = MaxHealth;
    }
    
    /// <summary>
    /// Whenever you click the capsule
    /// (In a 'real' game, this would somehow be done by a bullet or smth hitting the player)
    /// </summary>
    private void OnMouseDown()
    {
        Debug.Log("Clicked");
        // make sure health decreases
        Decrease(10);
    }
    
    /// <summary>
    /// Decrease the health by the specified amount
    /// </summary>
    /// <param name="amount">The amount to decrease the health by</param>
    private void Decrease(int amount)
    {
        CurrentHealth -= amount;
        Debug.Log(CurrentHealth);
        
        // todo: Let the world (more specifically: the health bar) know the new CurrentHealth
    }
}
