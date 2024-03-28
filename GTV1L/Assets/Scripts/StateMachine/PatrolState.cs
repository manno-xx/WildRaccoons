using UnityEngine;

public enum States
{
    Patrol,
    Follow,
    Confused
}

/// <summary>
/// State run when virtual CCTV camera happily rotates without being aware of anything
/// Transitions to Follow if player is seen
/// </summary>
public class PatrolState : CameraState
{
    [SerializeField] private float RotationSpeed = 30;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        animator.GetComponent<Renderer>().material.color = Color.green;
    }
    
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);
        
        if(SeePlayer(animator.transform, playerTransform, CameraHalfFoV)){
            animator.SetInteger(CameraStateParameter, (int) States.Follow);
        }
    }
}
