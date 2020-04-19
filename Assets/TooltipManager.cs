using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipManager : MonoBehaviour
{
    public GameObject TooltipPrefab;
    private GameObject currentTooltip;
    //public Text TooltipText;
    //public Image TooltipImage = null;

    public void SetTooltipInfo(string txt, Sprite img = null)
    {
        HideTooltip();
        ShowTooltip();

        currentTooltip.GetComponentInChildren<Text>().text = txt;

        if(img != null)
            currentTooltip.GetComponentInChildren<Image>().sprite = img;
    }

    public void ShowTooltip()
    {
        Debug.Log("Show tooltip!");
        currentTooltip = Instantiate(TooltipPrefab, this.transform);
    }

    public void HideTooltip()
    {
        if(currentTooltip != null)
            Destroy(currentTooltip);
    }

    public void CreateTooltip(string txt, float lifespan, Sprite img = null)
    {
        GameObject obj = Instantiate(TooltipPrefab, this.transform);
        obj.GetComponentInChildren<Text>().text = txt;
        obj.GetComponent<FullyDestroyAfterDelay>().DestroyAfterDelay(lifespan);
    }
}
