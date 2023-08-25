using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeCollider : MonoBehaviour
{
    private void Start()
    {
        Invoke("Disible", 0.4f);
    }
    private void Disible()
    {
        GetComponent<MeshCollider>().enabled = false;
    }
}
