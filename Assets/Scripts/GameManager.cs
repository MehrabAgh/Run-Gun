using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform Player;
    public bool _isAction, _isMenu = true;
    public float timeAction;
    public EnemyResource ActionEntered;
    public bool upAction, downAction;
    public ModelLayer model;
    [SerializeField]private float x;
    private void Awake()
    {
        instance = this;
        _isMenu = true;
    }
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {       
        if (_isMenu)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isMenu = false;
            }
        }
        else if(model != null)
        {
            if (upAction)
            {                
               // UpTimeLayers(ModelLayer.currAnim, ModelLayer.LayerIndex, ModelLayer.time);
            }
            if (downAction)
            {
                model.time = Mathf.Lerp(model.time, 0.0f, Time.deltaTime/0.4f);
                model.currAnim.SetLayerWeight(model.LayerIndex, model.time);                
                if (model.time <= 0.0f)
                {
                    downAction = false;
                    model = null;
                }              
            }
        }           
    }  
    public void UpTimeLayers(Animator anim, int layerIndex, float time)
    {
        time = Mathf.Lerp(time, 1.0f, Time.deltaTime);
        anim.SetLayerWeight(layerIndex, time);
        if (time >= 1.0f)
        {
            upAction = false;
        }
    }
}
