using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Prefab;
    public GameObject Prefab_Inst;

    public Transform ParentTrans;
    public Int32 Option;
    Vector3 scaleAxis;
    Vector3 SetScale;
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
        Prefab_Inst = Instantiate(Prefab, ParentTrans);
        Prefab_Inst.transform.localPosition = Vector3.zero;
        Prefab_Inst.transform.localScale = SetScale;
        Prefab_Inst.transform.localRotation = Quaternion.identity ;
    }
    public void Place()
    {
        if (Prefab_Inst)
        {
            Prefab_Inst.transform.parent = null;
            Prefab_Inst = null;
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
}
