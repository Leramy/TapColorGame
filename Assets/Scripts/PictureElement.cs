using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureElement : MonoBehaviour
{
    [SerializeField] private GameObject paletteController;
    public void OnMouseDown()
    {
        var palette = paletteController.GetComponent<PaletteController>();
        GetComponent<Renderer>().material.color = palette.CurrentColor.MainMaterial.color;
    }
}
