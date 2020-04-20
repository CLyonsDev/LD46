using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterDisplayPopup : MonoBehaviour
{
    public TooltipManager TooltipManager;

    private bool hasSpawned = false;
    public string contents;
    public float duration;

    private void OnTriggerEnter(Collider other)
    {
        if(!hasSpawned)
        {
            hasSpawned = true;
            TooltipManager.CreateTooltip(contents, duration);
        }
    }
}
