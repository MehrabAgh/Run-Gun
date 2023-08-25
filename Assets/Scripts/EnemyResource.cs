using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyResource : MonoBehaviour
{
    public List<Transform> Enemys;
    public List<Transform> EnePar;
    public GameObject offset;
    public EnemyResource resBefour;

    void DisableTrigger()
    {
        GetComponent<BoxCollider>().isTrigger = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        Invoke("DisableTrigger", 1f);
    }
    private void Update()
    {
        Enemys.RemoveAll(item => item == null);
        if (Enemys.Count < 1)
        {
            Destroy(gameObject);
        }
        if (GameManager.instance._isAction)
        {
            if (CameraMove.ins.getAct == 3)
            {
                if (EnePar.Count > 0)
                {
                    foreach (var item in EnePar)
                    {
                        item.gameObject.SetActive(true);
                    }
                }
            }
            foreach (var item in Enemys)
            {
                if (item.GetComponent<Enemy>() != null)
                {                   
                    item.GetComponent<Enemy>().count = 1;
                }
                else
                {
                    if(item.GetComponentInChildren<Enemy>())
                    item.GetComponentInChildren<Enemy>().count = 1;
                }
            }
        }        
    }
}
