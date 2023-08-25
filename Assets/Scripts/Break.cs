using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    public Transform brokenObject;
    public float magnitudeCol, radius, power, upwards;
    private Transform ok;    
    void Breaking(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > magnitudeCol)
        {
            Destroy(gameObject);
            ok = Instantiate(brokenObject, transform.position, transform.localRotation);
            
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

            foreach (Collider hit in colliders)
            {
                if (hit.GetComponent<Rigidbody>())
                {
                    hit.GetComponent<Rigidbody>().AddExplosionForce(power * collision.relativeVelocity.magnitude, explosionPos, radius, upwards);
                }
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(gameObject.name == "Shield (1)") 
        {
            if (collision.gameObject.tag == "Ammo")
            {
                Breaking(collision);                
            }
        }
        else
        {
            Breaking(collision);
        }
        
    }
}
