using UnityEngine;

/// <summary>
/// An interactible that destroys itself when interacted with
/// <seealso cref="IInteractible"/>
/// </summary>
public class InteractDestroy : MonoBehaviour, IInteractible
{
    public void Interact()
    {
        Destroy(gameObject);
    }
}
