using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayChecker : MonoBehaviour
{
    public float dist;
    private void Update()
    {
        dist = Vector3.Distance(transform.position, GameManager.instance.Player.position);
        if (dist <= 2)
        {
            gameObject.tag = "Untagged";
        }
    }
}
