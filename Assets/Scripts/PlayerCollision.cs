using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerCollision : MonoBehaviour
{    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Action")
        {
            GameManager.instance.ActionEntered = other.gameObject.GetComponent<EnemyResource>();
            int.TryParse(other.gameObject.name.Substring(7), out CameraMove.ins.getAct);
            foreach (var item in other.GetComponent<EnemyResource>().Enemys)
            {
                item.gameObject.SetActive(true);
            }
            GetComponent<PlayerEneDetect>().offset = other.GetComponent<EnemyResource>().offset;
            //GameManager.instance._isAction = true;
            if (other.GetComponent<EnemyResource>().resBefour != null) {
                foreach (var item in other.GetComponent<EnemyResource>().resBefour.Enemys)
                {
                    Destroy(item.gameObject);
                }
            }
        }
        if (other.gameObject.tag == "AmmoEnemy")
        {
            GetComponent<Animator>().SetLayerWeight(6, 1);
            GetComponent<Animator>().SetBool("_death", true);
            MenuManager.ins.GameOver();
        }
        if (other.gameObject.tag == "endPoint")
        {
            GetComponent<Animator>().SetLayerWeight(5, 1);
            MenuManager.ins.GameOver();
        }
    }
}
