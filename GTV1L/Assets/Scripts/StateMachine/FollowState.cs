using UnityEngine;

/// <summary>
/// State run when player is in sight
/// Follow the player
/// Transitions to Confused when sight of player is lost
/// </summary>
public class FollowState : CameraState
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        animator.transform.GetComponent<Renderer>().material.color = Color.red;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // if NOT seeing the player anymore
        if (!SeePlayer(animator.transform, playerTransform, CameraHalfFoV))
        {
            //  transition to confused state
            animator.SetInteger(CameraStateParameter, (int) States.Confused);
        }
        else
        {
            //   rotate to where the player is
            Vector3 target = playerTransform.position;
            // only rotate on y axis
            target.y = animator.transform.position.y;
            // rotateTowards the player position at a given max speed
            Vector3 targetRotation = target - animator.transform.position;
            // let unity rotate towards
            Vector3 newRotation =
                Vector3.RotateTowards(
                    animator.transform.forward, 
                    targetRotation, 
                    Mathf.Deg2Rad * 45 * Time.deltaTime, 
                    0);
            animator.transform.rotation = Quaternion.LookRotation(newRotation);
        }
    }
}
