using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    RaycastHit hit;
    public GameObject obHit;
    private Color col;
    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 25, Color.green);
        ChangeAlpha();
        if (Physics.Raycast(transform.position,transform.forward,out hit,25))
        {
            if (hit.collider.tag == "Alpha")
            {
                obHit = hit.collider.gameObject;
                col = obHit.GetComponent<MeshRenderer>().material.color;
            }
        }
    }
    private void ChangeAlpha()
    {
        if (obHit != null)
        {                      
            col.a = Mathf.Lerp(col.a, 0,Time.deltaTime/0.1f);
            obHit.GetComponent<MeshRenderer>().material.color = col;
        }
    }
}