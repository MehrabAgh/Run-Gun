using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemy : MonoBehaviour
{
    #region VariableGun       
    public GameObject preAmmo;
    private GameObject insAmmo;
    public float power;
    public Transform pivot;
    public int maxAmmo = 1;
    public bool ss , gg;
    #endregion

    void Update()
    {
        if (gg)
        {
            if (ss)
            {
                if (maxAmmo > 0)
                {
                    insAmmo = Instantiate(preAmmo, transform.position, transform.rotation);
                    insAmmo.GetComponent<Rigidbody>().AddForce(-insAmmo.transform.up * power);
                    maxAmmo--;
                }
            }
        }
    }
}
