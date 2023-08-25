using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    public Transform Target;
    public Quaternion oriPos;
    private void Awake()
    {
        oriPos = transform.rotation;
    }
    public void rot()    
    {
     //   Target = GameManager.instance.EnemyDetect.transform;
        if (GameManager.instance._isAction && Target != null)
        {
            transform.LookAt(Target);            
        }
    }
    public void pos()
    {
        transform.rotation = oriPos;
    }
}
