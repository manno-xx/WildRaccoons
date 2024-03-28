using UnityEngine;

/// <summary>
/// Parent class of all camera states (Patrol, Follow, Lost)
/// 
/// </summary>
public class CameraState : StateMachineBehaviour
{
    protected int CameraHalfFoV = 30;
    
    // will contain the Hash (a unique ID, not the other thing) of the parameter that triggers the transitions.
    protected int CameraStateParameter;

    protected Transform playerTransform;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Only type the name once (and no longer run into typo-related errors like I did in class)
        CameraStateParameter = Animator.StringToHash("CameraState");
        playerTransform = GameObject.FindWithTag("Player").transform;
        
        SetUpCamera(animator);
    }
    
    /// <summary>
    /// Make sure the calculations of FoV are done based on the CCTV's camera settings.
    /// </summary>
    /// <param name="animator"></param>
    /// <returns></returns>
    private void SetUpCamera(Animator animator)
    {
        Camera cctv = animator.GetComponent<Camera>();
        CameraHalfFoV = (int) (cctv.fieldOfView * 0.5f);
    }
    
    /// <summary>
    /// Determines if one game object 'sees' another.
    /// Calculate the angle between transform.forward of 'camera' and the vector from cameraTransform to playerTransform
    /// Returns true if angle is less than the provided minAngle. 
    /// </summary>
    /// <param name="cameraTransform">The transform of the 'camera' (does not need to be an actual Camera)</param>
    /// <param name="playerTransform">The transform of the object to spot (does not need to be the player)</param>
    /// <param name="minAngle">The minimum angle considering to still be in FoV</param>
    /// <returns></returns>
    public bool SeePlayer(Transform cameraTransform, Transform playerTransform, float minAngle)
    {
        // get the Vector3 from this/camera to player
        Vector3 camToPlayer = playerTransform.position - cameraTransform.position;
        // calculate the angle of that vector with the forward vector
        float angle = Vector3.Angle(cameraTransform.forward, camToPlayer);
        // if the angle is <= 30, camera sees the player
        if (angle <= minAngle && SeePlayer(cameraTransform, playerTransform))
        {
            return true;
        }
        return false;
    }
    
    /// <summary>
    /// Determines if the player is 'seen'
    /// Casts a ray from the camera in the direction of the player
    /// If it hits the player, it sees it
    /// </summary>
    /// <param name="origin">Transform to cast the ray from</param>
    /// <param name="playerTransform">The object in which's direction to cast the ray</param>
    /// <returns></returns>
    public bool SeePlayer(Transform origin, Transform playerTransform)
    {
        Vector3 camToPlayer = playerTransform.position - origin.position;
        if (Physics.Raycast(
                origin.position,
                camToPlayer,
                out RaycastHit hitInfo,
                10))
        {
            if (hitInfo.transform.CompareTag("Player"))
            {
                return true;
            }
        }

        return false;
    }
}
