using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCursor : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
