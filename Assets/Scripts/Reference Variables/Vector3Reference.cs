using UnityEngine;

[System.Serializable]
public class Vector3Reference
{

    public bool UseConstant = false;
    public Vector3 ConstantValue;
    public Vector3Variable Variable;

    public Vector3 Value
    {
        get { return UseConstant ? ConstantValue : Variable.Value; }
        set
        {
            if (UseConstant)
                ConstantValue = value;
            else
                Variable.Value = value;
        }
    }
}
