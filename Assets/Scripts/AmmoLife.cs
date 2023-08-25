using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoLife : MonoBehaviour
{    
    private void Start()
    {
        Destroy(this.gameObject, 0.4f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Ammo") 
        {
            if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemyBody")
            {                
                other.GetComponentInParent<Enemy>().health--;                
            }
            if (other.gameObject.tag == "Item")
            {
                other.GetComponent<Explosion>()._iscollised = true;                
            }
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<SphereCollider>().isTrigger = true;
    }
}
