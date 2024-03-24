using UnityEngine;

/// <summary>
/// An interactible that bounces up into the air when interacted with
/// <seealso cref="IInteractible"/>
/// </summary>
public class InteractKick : MonoBehaviour, IInteractible
{
    private Rigidbody rb;
    
    /// <summary>
    /// Get reference to RigidBody component for future use
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Apply an upwards force to the rigidbody component
    /// </summary>
    public void Interact()
    {
        rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
    }
}
