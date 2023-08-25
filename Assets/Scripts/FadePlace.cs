using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadePlace : MonoBehaviour
{
    public Material myMat;
    private void Start()
    {
        myMat = GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        if(myMat.color.a <= 0.5f)
        {
            Destroy(GetComponent<BoxCollider>());
        }
    }
}
