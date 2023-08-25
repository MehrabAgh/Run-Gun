using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setTarget : MonoBehaviour
{      
    private void OnMouseDown()
    {
        GameManager.instance.Player.GetComponentInChildren<GunRotation>().Target = gameObject.transform;
    }
}
