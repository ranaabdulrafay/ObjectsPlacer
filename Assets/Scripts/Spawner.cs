using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Spawner : MonoBehaviour
{
    public GameObject Prefab;
    public GameObject Prefab_Inst;

    public Transform ParentTrans;
    public Int32 Option;
    Vector3 scaleAxis;
    Vector3 SetScale;

    public bool IsFloor = false;
    public ARRaycastManager m_RaycastManager;
    // Start is called before the first frame update
    void Start()
    {
        SetScale = Vector3.one;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Spawn()
    {
        if(IsFloor)
        {

        }
        else
        {
            Prefab_Inst = Instantiate(Prefab, ParentTrans);
            Prefab_Inst.transform.localPosition = Vector3.zero;
            Prefab_Inst.transform.localScale = SetScale;
            Prefab_Inst.transform.localRotation = Quaternion.identity;
        }
        
    }
    public void Place()
    {
        if (Prefab_Inst)
        {
            //Prefab_Inst.transform.parent = null;
            Prefab_Inst = null;
        }
    }
    public void RotateUp()
    {
        if (Prefab_Inst)
        {
            switch (Option)
            {
                case 0:
                    scaleAxis = Vector3.right;
                    break;
                case 1:
                    scaleAxis = Vector3.up;
                    break;
                case 2:
                    scaleAxis = Vector3.forward;
                    break;
            }
            Prefab_Inst.transform.Rotate(scaleAxis,15);
            SetScale = Prefab_Inst.transform.localScale;
        }
    }
    public void RotateDown() 
    {
        if (Prefab_Inst)
        {
            switch (Option)
            {
                case 0:
                    scaleAxis = Vector3.right;
                    break;
                case 1:
                    scaleAxis = Vector3.up;
                    break;
                case 2:
                    scaleAxis = Vector3.forward;
                    break;
            }
            Prefab_Inst.transform.Rotate(scaleAxis, -15);
            SetScale = Prefab_Inst.transform.localScale;
        }
    }
    public void ScaleUp()
    {
        if (Prefab_Inst)
        {
            switch (Option)
            {
                case 0:
                    scaleAxis = Vector3.right;
                    break;
                case 1:
                    scaleAxis = Vector3.up;
                    break;
                case 2:
                    scaleAxis = Vector3.forward;
                    break;
            }
            Prefab_Inst.transform.localScale += scaleAxis * 0.1f;
            SetScale = Prefab_Inst.transform.localScale;
        }
    }
    public void ScaleDown()
    {
        if (Prefab_Inst)
        {
            switch (Option)
            {
                case 0:
                    scaleAxis = Vector3.right;
                    break;
                case 1:
                    scaleAxis = Vector3.up;
                    break;
                case 2:
                    scaleAxis = Vector3.forward;
                    break;
            }
            Prefab_Inst.transform.localScale -= scaleAxis * 0.1f;
            SetScale = Prefab_Inst.transform.localScale;
        }
    }

    public void SetValue(Int32 _value)
    {
        Option = _value;
    }

    public void MoveAway()
    {
        if(Prefab_Inst)
        {
            Prefab_Inst.transform.position += ParentTrans.forward * 0.1f;
        }
    }
    public void MoveClose()
    {
        if (Prefab_Inst)
        {
            Prefab_Inst.transform.position -= ParentTrans.forward * 0.1f;
        }
    }
    public void NextScene()
    {
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex >= UnityEngine.SceneManagement.SceneManager.sceneCount)
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        else
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex+1);
    }
}
