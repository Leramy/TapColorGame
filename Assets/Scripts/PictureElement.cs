using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureElement : MonoBehaviour
{
    [SerializeField] private LevelController levelController;
    [SerializeField] private GameObject paletteController;

    //Соседние объекты, с которыми будем сравнивать цвет
    [SerializeField] private PictureElement[] neighbours;

    private Color selfColor;
    public Color SelfColor
    {
        get { return selfColor; }
        set
        {
            if (value != null)
            {
                GetComponent<Renderer>().material.color = value;
                selfColor = value;
            }
        }
    } 

    public void OnMouseDown()
    {
        //Узнаем текущий выделенный цвет
        var palette = paletteController.GetComponent<PaletteController>();
        Color newColor = palette.GetColor();

        // Если есть сосед с таким же цветом, то помечаем, что элемент окрашен неверно(0), в противном случе - 1
        if (CheckNeighboursColor(newColor))
        {
            levelController.AddState(this.name, 1);
        }
        else
            levelController.AddState(this.name, 0);

        SelfColor = newColor;

        foreach (PictureElement neighbour in neighbours)
        {
            neighbour.RefreshState();
        }

    }

    private bool CheckNeighboursColor(Color newColor)
    {
        foreach(PictureElement neighbour in neighbours)
        {
            if (newColor == neighbour.SelfColor)
                return false;
        }
        return true;
    }

    public void RefreshState()
    {
        if (CheckNeighboursColor(selfColor))
        {
            levelController.AddState(this.name, 1);
        }
        else
            levelController.AddState(this.name, 0);
    }
}
