using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndActionPart2 : StateMachineBehaviour
{
    public float tim;
    ModelLayer ML2 = new ModelLayer();
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetLayerWeight(layerIndex) > 0)
        {
            //GameManager.instance._isAction = true;
          //  GameManager.instance.Player.GetComponent<BoxCollider>().enabled = false;
          //  GameManager.instance.Player.GetComponent<Rigidbody>().isKinematic = true;
            animator.applyRootMotion = true;
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetLayerWeight(layerIndex) > 0)
        {     
            GameManager.instance.downAction = true;
            ML2.currAnim = animator;
            ML2.LayerIndex = layerIndex;
            ML2.time = tim;           
            GameManager.instance._isAction = false;
            animator.SetBool("sAct2", false);
            GameManager.instance.Player.GetComponent<CapsuleCollider>().enabled = true;                      
            animator.applyRootMotion = false;
            GameManager.instance.Player.GetComponent<Rigidbody>().isKinematic = false;
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
            GameManager.instance.model = ML2;
            if (AllSame())
            {
                GameManager.instance._isAction = false;
                animator.SetBool("sAct2", false);
                animator.applyRootMotion = false;
                GameManager.instance.Player.GetComponent<Rigidbody>().isKinematic = false;
                GameManager.instance.Player.GetComponent<Movement>().speed = 13;
            }
            else
            {
                GameManager.instance.Player.GetComponent<Movement>().speed = 0;
                if (stateInfo.normalizedTime >= 0.4f)
                {
                    GameManager.instance.Player.GetComponent<BoxCollider>().enabled = true;
                    GameManager.instance.Player.GetComponent<CapsuleCollider>().enabled = true;
                    animator.SetBool("sAct2", false);
                }
                if (stateInfo.normalizedTime >= 0.3f && stateInfo.normalizedTime < 0.4f)
                {
                    GameManager.instance._isAction = true;
                    GameManager.instance.Player.GetComponent<CapsuleCollider>().enabled = false;
                    //GameManager.instance.Player.GetComponent<BoxCollider>().enabled = false;
                    //GameManager.instance.Player.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }
    }
}
