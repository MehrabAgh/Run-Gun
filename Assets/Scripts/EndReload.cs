using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndReload : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("_reload", false);
        animator.SetLayerWeight(layerIndex, 0);
    }
}
