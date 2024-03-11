using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

/// <summary>
/// Defines a health system
/// </summary>
public class Health : MonoBehaviour
{
    // the health (current and max) values
    [Header("health settings")] // this makes the inspector look a bit more organized.
    [SerializeField] private float currentHealth = 0;
    [SerializeField] private float maxHealth = 600; // Should you be able to change the value of this in the inspector? Probably...

    [SerializeField] private UnityEvent<float> healthUpdate;
    [SerializeField] private UnityEvent gameOver;
    
    /// <summary>
    /// Make sure the player start at max health
    /// .. and the UI is updated
    /// </summary>
    void Start()
    {
        currentHealth = maxHealth;
        BroadcastEvents();
    }
    
    /// <summary>
    /// Whenever you click the capsule
    /// (In a 'real' game, this would somehow be done by a bullet or smth hitting the player)
    /// </summary>
    private void OnMouseDown()
    {
        // make sure health decreases
        Decrease(10);
    }
    
    /// <summary>
    /// Decrease the health by the specified amount
    /// </summary>
    /// <param name="amount">The amount to decrease the health by</param>
    public void Decrease(float amount)
    {
        currentHealth -= amount;

        BroadcastEvents();
    }

    /// <summary>
    /// Broadcast/invoke the unity events
    /// </summary>
    private void BroadcastEvents()
    {
        healthUpdate.Invoke(currentHealth/maxHealth);

        if (currentHealth <= 0)
        {
            gameOver.Invoke();
        }
    }
}
