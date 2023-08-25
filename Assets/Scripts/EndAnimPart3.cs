using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnimPart3 : StateMachineBehaviour
{
    public float tim;
    ModelLayer ML = new ModelLayer();
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetLayerWeight(layerIndex) > 0)
        {
            GameManager.instance._isAction = true;
            GameManager.instance.Player.GetComponent<CapsuleCollider>().enabled = false;
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetLayerWeight(layerIndex) > 0)
        {
            animator.SetBool("sAct3", false);
            animator.applyRootMotion = false;
            GameManager.instance._isAction = false;
            GameManager.instance.downAction = true;
            ML.currAnim = animator;
            ML.LayerIndex = layerIndex;
            ML.time = tim;
            GameManager.instance.Player.GetComponent<BoxCollider>().enabled = true;
            if (AllSame())
            {
                GameManager.instance.Player.GetComponent<Movement>().speed = 13;
            }
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
                animator.SetBool("sAct3", false);
                animator.applyRootMotion = false;
                GameManager.instance.Player.GetComponent<Rigidbody>().isKinematic = false;
                GameManager.instance.Player.GetComponent<Movement>().speed = 13;
                GameManager.instance.Player.GetComponent<CapsuleCollider>().enabled = true;
                GameManager.instance.Player.GetComponent<BoxCollider>().enabled = true;
            }
            else
            {
                GameManager.instance.Player.GetComponent<Movement>().speed = 0;
                if (stateInfo.normalizedTime >= 0.6f)
                {
                    animator.applyRootMotion = false;
                    GameManager.instance.Player.GetComponent<CapsuleCollider>().enabled = true;
                    GameManager.instance.Player.GetComponent<Rigidbody>().AddForce(0, -80, 0);
                }
                if (stateInfo.normalizedTime <= 0.1f && stateInfo.normalizedTime < 0.6f)
                {
                    GameManager.instance._isAction = true;
                    GameManager.instance.Player.GetComponent<CapsuleCollider>().enabled = false;
                    GameManager.instance.Player.GetComponent<BoxCollider>().enabled = false;
                }
            }
        }
    }
}
