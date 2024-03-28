using UnityEngine;

/// <summary>
/// State run when camera lost sight of player
/// Either
/// - transitions to Patrol after x seconds or
/// - transitions to follow if player is seen before that 
/// </summary>
public class ConfusedState : CameraState
{
    [SerializeField] private float WaitTime = 3;

    private float StateEnterTime;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        animator.GetComponent<Renderer>().material.color = Color.yellow;
        
        StateEnterTime = Time.time;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // if wait time has passed
        if (Time.time > StateEnterTime + WaitTime)
        {
            //  to Patrol State again
            animator.SetInteger(CameraStateParameter, (int) States.Patrol);
        }
        else if (SeePlayer(animator.transform, playerTransform, CameraHalfFoV))
        {
            // else, if see the player again
            //  to follow state again    
            animator.SetInteger(CameraStateParameter, (int) States.Follow);
        }
    }
}
