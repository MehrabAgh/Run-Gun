using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private List<GameObject> Waypoints;
    private Transform SubmitWay;
    private Vector3 Currpos;
    public float speed;
    private Animator ani;
    public Transform bone;
    private void Start()
    {
        ani = GetComponent<Animator>();
    }
    private void LateUpdate()
    {
        if (!GameManager.instance._isMenu)
        {
            Waypoints = GameObject.FindGameObjectsWithTag("Way").ToList();
            FindTarget();
            if (SubmitWay != null)
            {
                if (GameManager.instance._isAction)
                {
                    Currpos = transform.position;
                    transform.position = Currpos;
                    Rotating(GetComponent<PlayerEneDetect>().offset.transform);
                }
                else
                {
                    RotatingOrig(SubmitWay);
                }
                if (Waypoints.Count > 0)
                {
                    Moving();
                }
            }
        }
    }

    private void Rotating(Transform target)
    {
        bone.transform.rotation = Quaternion.Slerp(bone.transform.rotation,
        Quaternion.LookRotation(target.position - bone.transform.position, Vector3.up), 5 * Time.deltaTime);
    }
    private void RotatingOrig(Transform target)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation,
        Quaternion.LookRotation(target.position - transform.position, Vector3.up), 5 * Time.deltaTime);
    }
    private void Moving()
    {        
        transform.position += transform.forward * Time.deltaTime * speed;
        ani.SetFloat("move", 1);
    }
    private void FindTarget()
    {
        float lowestDist = Mathf.Infinity;
        for (int i = 0; i < Waypoints.Count; i++)
        {
            float dist = Vector3.Distance(Waypoints[i].transform.position, transform.position);
            if (dist < lowestDist)
            {
                lowestDist = dist;
                SubmitWay = Waypoints[i].transform;
            }
        }
    }
}
