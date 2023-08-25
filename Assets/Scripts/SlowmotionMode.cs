using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowmotionMode : MonoBehaviour
{
    public float slowDownfactor;
    public float slowDownLength;
    public void SlowMotion()
    {
        Time.timeScale = slowDownfactor;
        Time.fixedDeltaTime = Time.timeScale * .03f;
    }
    void Update()
    {
        if (GameManager.instance._isAction)
        {
            SlowMotion();
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
