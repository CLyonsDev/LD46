using UnityEngine;

[CreateAssetMenu(fileName = "Vector3 Variable", menuName = "Scriptable Object Variables/Vector3 Variable")]
public class Vector3Variable : ScriptableObject
{
    public Vector3 Value;

    [TextArea(3, 10)]
    public string Description;
}
