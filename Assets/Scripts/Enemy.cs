using RootMotion.FinalIK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum stateManage
    {
        Idle,
        Attack,
        Death
    }
    public List<SkinnedMeshRenderer> myMats;  
    public Color DeathCol1 , DeathCol2 , DeathCol3;

    public int count;
    public stateManage State;
    private Transform target;
    public float _timeAction;
    public int health = 2;
    public bool _isDeath;
    public Transform gun, pivGun;
    public GameObject PSBlood;
    //
    private void Start()
    {
        target = GameManager.instance.Player;
        _timeAction = GameManager.instance.timeAction;                
    }   
    private void Update()
    {
        if (target == null)
        {
            target = GameManager.instance.Player;
        }
        transform.LookAt(target);
        if (_isDeath)
        {
            if (myMats.Count > 0)
            {
                for (int i = 0; i < myMats.Count; i++)
                {
                    if(myMats[i].material.name == "pants (Instance)")
                    {
                        myMats[i].material.color = DeathCol1;
                    }
                    if (myMats[i].material.name == "kerevt (Instance)")
                    {
                        myMats[i].material.color = DeathCol2;
                    }
                    if (myMats[i].material.name == "Material.002 (Instance)")
                    {
                        myMats[i].material.color = DeathCol3;
                    }
                }
            }
            PSBlood.SetActive(true);
            if (GetComponent<CapsuleCollider>())
            {
                GetComponent<CapsuleCollider>().enabled = false;
            }
            if (gun)
            {
                Destroy(gun.gameObject);
            }
            if(GetComponent<FullBodyBipedIK>() != null)
            {
                GetComponent<FullBodyBipedIK>().enabled = false;
            }
            Destroy(GetComponent<Animator>());
            Invoke("Destoryed", 0.7f);
        }
        if (count > 0 && !GameManager.instance._isAction) 
        {                    
            _timeAction -= Time.deltaTime;
            if (_timeAction <= 0)
            {
                State = stateManage.Attack;                
                GetComponentInChildren<ShootEnemy>().ss = true;
                //shoot
            }
        }
        if (health <= 0)
        {
            State = stateManage.Death;
            //death
        }       
        switch (State)
        {
            case stateManage.Idle:
                //idle
                break;
            case stateManage.Attack:                
                break;
            case stateManage.Death:
                _isDeath = true;
                break;
            default:
                break;
        }
    }
    IEnumerator StopRagdoll()
    {
        yield return new WaitForSeconds(0.05f);
       
         
    }
    private void Destoryed()
    {
        Destroy(gameObject);
    }
}