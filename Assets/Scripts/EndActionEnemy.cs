using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndActionEnemy : StateMachineBehaviour
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime >= 0.8f)
        {
            animator.SetBool("Enable", false);
        }
    }
}
