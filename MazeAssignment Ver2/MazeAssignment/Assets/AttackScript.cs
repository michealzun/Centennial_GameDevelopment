using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : StateMachineBehaviour {
    EnemyVer2 owner;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<Renderer>().material = Resources.Load("materials/Red", typeof(Material)) as Material;
        owner = animator.gameObject.GetComponent<EnemyVer2>();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (animator.gameObject.GetComponent<EnemyVer2>().ammoCount >0 && animator.gameObject.GetComponent<EnemyVer2>().shotCD >0.5f)
        {
            Vector3 shotDirection = Vector3.Normalize(owner.directionToPlayer);// + Random.insideUnitSphere * 0.3f;
            Instantiate(Resources.Load("Bullet") as GameObject, animator.gameObject.transform.position, Quaternion.LookRotation(shotDirection));
            animator.gameObject.GetComponent<EnemyVer2>().ammoCount--;
            owner.shotCD = 0;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state Vector3.Normalize(owner.directionToPlayer)
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
