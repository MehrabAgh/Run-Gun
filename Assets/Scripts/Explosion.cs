using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float radius = 5 , power = 10 , upForce = 1;
    public bool _iscollised;
    public GameObject PSExp;
    private void FixedUpdate()
    {
        if (_iscollised)
        {
            PSExp.transform.SetParent(null);
            PSExp.SetActive(true);
            _explosion();           
            Destroy(gameObject);
        }
    }
    private void _explosion()
    {
        Vector3 expPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(expPos, radius);
      
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, expPos, radius, upForce, ForceMode.Impulse);
            }
            foreach (Collider cc in colliders)
            {
                if (cc.GetComponent<Enemy>())
                {
                    cc.GetComponent<Enemy>().health = 0;
                    if (cc.GetComponent<Animator>())
                    cc.GetComponent<Animator>().enabled = false;                    
                }
                if (cc.GetComponent<Explosion>())
                {
                    Destroy(cc.gameObject);
                }
            }
        }
    }
}
