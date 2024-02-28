using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Script that deals with the movement of the player
/// Uses WASD/arrow keys
/// </summary>
public class Movement : MonoBehaviour
{
    // Defines the speed and makes sure the variable is exposed in the inspector for easy changing
    [SerializeField] private float speed = 4;

    /// <summary>
    /// Reads input on both input axis
    /// and then 'translates' (moves) the transform based on input and Speed
    /// </summary>
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        transform.Translate(Time.deltaTime * speed * movement);
    }
}
