using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeCarPaintColor : MonoBehaviour
{
    public GameObject[] PaintGOs;
    public List<Material> paintMaterials = new List<Material>();

    // Start is called before the first frame update
    void Awake()
    {
        foreach (GameObject gameObject in PaintGOs)
        {
            paintMaterials.Add(gameObject.GetComponent<Renderer>().materials[0]);
        }
    }

    public void RandomizePaintColor()
    {
        Color32 c = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);

        foreach (Material m in paintMaterials)
        {
            m.color = c;
        }
    }
}
