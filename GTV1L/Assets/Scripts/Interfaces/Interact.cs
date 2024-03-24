using UnityEngine;

/// <summary>
/// A component to interact with Interactibles
/// To be placed on 1st person view object
/// </summary>
public class Interact : MonoBehaviour
{
    [SerializeField] private LayerMask myMask;
    
    /// <summary>
    /// If e-key is pressed, a ray is cast to see if it hits a gameobject with a component implementing IInteractible
    /// If so, this script interacts with it
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // define the ray
            Ray ray = new Ray(transform.position, transform.forward);

            // cast it, and see what it hits (using a layer mask)
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 4, myMask))
            {
                // if the thing it hits implements IInteractible, interact with it
                if (hitInfo.transform.gameObject.TryGetComponent<IInteractible>(out IInteractible interactible))
                {
                    interactible.Interact();
                }
            }
        }
    }
}
