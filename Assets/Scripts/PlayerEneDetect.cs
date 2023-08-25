using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerEneDetect : MonoBehaviour
{
    public List<GameObject> Enemies;
    public GameObject offset;
    public static PlayerEneDetect ins;

    private void Awake()
    {
        ins = this;
    }
    private void Update()
    {
        if (GameManager.instance._isAction)
        {
            Enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();            
            if (Enemies.Count <= 0)
            {                
                GameManager.instance._isAction = false;                
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Action01")
        {
            GetComponent<Animator>().applyRootMotion = true;            
            GetComponent<Movement>().speed = 10f;
            GetComponent<Animator>().SetLayerWeight(1,1);
            GetComponent<Animator>().SetBool("sAct", true);
            other.GetComponent<EnemyResource>().Enemys[2].GetComponent<Animator>().SetBool("Enable", true);
        }
        if (other.gameObject.name == "Action02")
        {
           GetComponent<Movement>().speed = 0;
            GetComponent<Animator>().applyRootMotion = true;            
            GetComponent<Animator>().SetLayerWeight(3, 1);
            GetComponent<Animator>().SetBool("sAct2", true);
            GetComponent<CapsuleCollider>().enabled = false;
            //GetComponent<Rigidbody>().freezeRotation = false;
            //GetComponent<Animator>().updateMode = AnimatorUpdateMode.AnimatePhysics;
        }
        if (other.gameObject.name == "Action03")
        {
            GetComponent<Movement>().speed = 0;
            GetComponent<Animator>().applyRootMotion = true;
            GetComponent<Animator>().SetLayerWeight(2, 1);
            GetComponent<Animator>().SetBool("sAct3", true);
            //GetComponent<CapsuleCollider>().enabled = false;
        }
    }
}
