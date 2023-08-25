using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Vector3 menuPos , menuRot;
    public Vector3 defPos;
    public Vector3[] ActPoses , ActRotes;
    public CameraCollision defaultPos;
    public Transform parent;
    public int getAct;
    public static CameraMove ins;
    private float spdMove , spdRotate;
    private bool enbl = true , enbl2 = true;

    private void PositionCam(Vector3 pos)
    {
        transform.position = Vector3.Lerp(transform.position, pos, spdMove);
    }
    private void RotationCam(Vector3 rot)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.Euler(rot), spdRotate); 
    }
    private void LocalPositionCam(Vector3 pos)
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, pos, Time.deltaTime/ spdMove);
    }
    private void LocalRotationCam(Vector3 rot)
    {
        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(rot), Time.deltaTime / spdRotate);
    }

    private void MoveX()
    {
        var posZ = transform.position;
        posZ.x += Time.deltaTime* 15f ;
        transform.position = posZ;
    }
    private void MoveZ()
    {
        var posZ = transform.position;
        posZ.z += Time.deltaTime * -15f;
        transform.position = posZ;
    }
    private void Awake()
    {
        ins = this;
    }
    private void Update()
    {
        if (!GameManager.instance._isAction && !GameManager.instance._isMenu)
        {
            //transform.SetParent(parent);
            spdMove = 0.21f;
            spdRotate = 0.6f;
            LocalPositionCam(parent.position);
            LocalRotationCam(parent.rotation.eulerAngles);
        }
        if (!GameManager.instance._isAction && GameManager.instance._isMenu)
        {
           // transform.SetParent(null);
            PositionCam(menuPos);
            RotationCam(menuRot);
        }
        if (GameManager.instance._isAction && !GameManager.instance._isMenu)
        {
            //transform.SetParent(null);          
            switch (getAct)
            {
                case 1:
                    if (enbl)
                    {
                        spdMove = 0.2f;
                        spdRotate = 0.24f;
                        LocalPositionCam(ActPoses[0]);
                        LocalRotationCam(ActRotes[0]);
                    }
                   
                    if (transform.localPosition.x >= 77)
                    {
                        enbl = false;
                        MoveX();
                    }
                    break;
                case 2:
                    spdMove = 0.18f;
                    spdRotate = 0.2f;
                    LocalPositionCam(ActPoses[1]);
                    LocalRotationCam(ActRotes[1]);
                    break;
                case 3:
                    if (enbl2)
                    {
                        spdMove = 0.1f;
                        spdRotate = 0.1f;
                        LocalPositionCam(ActPoses[2]);
                        LocalRotationCam(ActRotes[2]);
                    }
                    if(transform.localPosition.x >= 157)
                    {
                        enbl2 = false;
                        MoveZ();
                    }
                    break;
                default:
                    break;
            }
        }

        #region TEST_PART_I
        //if (GameManager.instance._isAction)
        //{
        //    transform.localPosition = Vector3.Lerp(transform.localPosition, ActPosition, speed);
        //    transform.localRotation = Quaternion.Slerp(transform.localRotation, ActRotation, speed);
        //    // GetComponent<CameraCollision>().enabled = false;
        //}
        //else
        //{
        //    transform.localPosition = Vector3.Lerp(transform.localPosition, defPosition, speed);
        //    transform.localRotation = Quaternion.Slerp(transform.localRotation, defRotation, speed);
        //    //Invoke("EnableCollision", 0.4f);
        //    // EnableCollision();
        //}
        #endregion
        #region TEST_PART_II
        //if (GameManager.instance._isAction)
        //{
        //    transform.rotation = Quaternion.Slerp(transform.rotation,ActRotation, 5 * Time.deltaTime);            
        //    transform.position = Vector3.Lerp(transform.position, ActPosition, 0.08f);
        //}
        //else
        //{
        //    transform.rotation = Quaternion.Slerp(transform.rotation,
        // Quaternion.LookRotation(GameManager.instance.Player.position - transform.position, Vector3.up), 5 * Time.deltaTime);
        //    var pos = transform.position;
        //    pos.z = GameManager.instance.Player.position.z - 7;
        //    transform.position = Vector3.Lerp(transform.position, pos, 0.08f);
        //}
        #endregion
    }
}
