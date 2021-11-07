using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorElement : MonoBehaviour
{
    [SerializeField] private Image mainImage;

    private Material mainMaterial;
    
    /// <summary>
    /// �������� �������� � �������
    /// </summary>
    public Material MainMaterial
    {
        get { return mainMaterial; }
        set
        {
            if (value != null)
            {
                mainMaterial = value;
                if (mainImage != null)
                    mainImage.color = mainMaterial.color;
            }
        }
    }

    private Transform defaultParentTransform;
    /// <summary>
    /// Transform �������, � �������� ���������� �������
    /// </summary>
    public Transform DefaultParentTransform
    {
        get { return defaultParentTransform; }
        set
        {
            if (value != null)
                defaultParentTransform = value;
        }
    }

}
