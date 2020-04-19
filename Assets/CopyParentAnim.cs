using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyParentAnim : MonoBehaviour
{
    public Transform ParentToMirror;

    private Transform[] rig;
    private Transform[] parentRig;

    public bool Mirror = true;

    // Start is called before the first frame update
    void Awake()
    {
        rig = transform.GetComponentsInChildren<Transform>();
        parentRig = ParentToMirror.GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        //if(Mirror)
        //{
        //    CopyParent();
        //}
    }

    public void CopyParent()
    {
        for (int i = 0; i < rig.Length; i++)
        {
            rig[i].transform.position = parentRig[i].transform.position;
            rig[i].transform.rotation = parentRig[i].transform.rotation;
        }
    }
}
