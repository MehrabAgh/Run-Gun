using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public static Shoot ins;
    private float defultRelTime;
    private int defultAmmo;
    public int maxAmmo;
    public GameObject preAmmo;
    private GameObject insAmmo;
    public float power;
    public Transform pivot;
    public float reloadTime;

    private void Awake()
    {
        ins = this;
    }
    private void Start()
    {
        defultAmmo = maxAmmo;
        defultRelTime = reloadTime;
    }
    public void shooting()
    {
        insAmmo = Instantiate(preAmmo, pivot.position, pivot.rotation);
        insAmmo.GetComponent<Rigidbody>().AddForce(insAmmo.transform.forward * power);
        maxAmmo--;
    }
    private void Reload()
    {
        if (reloadTime <= 0)
        {
            maxAmmo = defultAmmo;
            reloadTime = defultRelTime;
            GetComponent<Animator>().SetBool("_reload", false);
        }
        else
        {            
            reloadTime -= Time.deltaTime;
            GetComponent<Animator>().SetBool("_reload", true);
            GetComponent<Animator>().SetLayerWeight(4, 1);
        }
    }
    private void Update()
    {
        if (!GameManager.instance._isAction) {
            if (maxAmmo < defultAmmo)
            {
                Reload();
            }
        }
        if (maxAmmo >= 0)
        {
            if (GameManager.instance._isAction)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    RaycastHit hitInfo = new RaycastHit();
                    bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
                    if (hit && hitInfo.transform.gameObject.tag != "Ground")
                    {                       
                        GetComponentInChildren<GunRotation>().Target = hitInfo.transform.gameObject.transform; 
                    }                    
                    GetComponentInChildren<GunRotation>().rot();
                    shooting();
                }
            }            
        }
        else
        {
            GetComponentInChildren<GunRotation>().pos();
            Reload();
        }
    }
}
