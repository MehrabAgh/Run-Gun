using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAction : StateMachineBehaviour
{
    public float tim;
    ModelLayer ML = new ModelLayer();    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetLayerWeight(layerIndex) > 0)
        {
            GameManager.instance._isAction = false;
            //           
            GameManager.instance.downAction = true;
            ML.currAnim = animator;
            ML.LayerIndex = layerIndex;
            ML.time = tim;            
            //
            animator.SetBool("sAct", false);           
            animator.applyRootMotion = false;
            GameManager.instance.Player.GetComponent<Movement>().speed = 15;
            GameManager.instance.Player.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
    bool AllSame()
    {
        for (int i = 0; i < GameManager.instance.ActionEntered.Enemys.Count; i++)
        {
            if (GameManager.instance.ActionEntered.Enemys[i].GetComponent<Enemy>() != null
                && GameManager.instance.ActionEntered.Enemys[i].GetComponent<Animator>() != null)
            {
                return false;
            }
        }
        return true;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {       
        if (animator.GetLayerWeight(layerIndex) > 0)
        {
            GameManager.instance.model = ML;
           
            if (AllSame())
            {
                GameManager.instance._isAction = false;
                animator.SetBool("sAct", false);
                animator.applyRootMotion = false;
                GameManager.instance.Player.GetComponent<Rigidbody>().isKinematic = false;
            }
            else
            {
                if (stateInfo.normalizedTime >= 0.75f)
                {
                    //  GameManager.instance._isAction = false;
                    GameManager.instance.Player.GetComponent<CapsuleCollider>().enabled = true;

                    animator.applyRootMotion = false;
                }
                if (stateInfo.normalizedTime >= 0.3f && stateInfo.normalizedTime < 0.75f)
                {
                    GameManager.instance._isAction = true;
                    GameManager.instance.Player.GetComponent<CapsuleCollider>().enabled = false;
                    GameManager.instance.Player.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }
    }
}
