using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PaletteController : MonoBehaviour
{
    [SerializeField] private GameObject colorPrefab;

    private ColorElement currentColor;

    /// <summary>
    /// Текущий выделенный цвет
    /// </summary>
    public ColorElement CurrentColor
    {
        get { return currentColor; }
        set
        {
            if (value != null)
                currentColor = value;
        }
    }

    public Color GetColor()
    {
        return currentColor.MainMaterial.color;
    }

    [SerializeField] private Transform scrollViewContent;

    [SerializeField] private List<Material> materials;


    void Start()
    {
        for (int i = 0; i < materials.Count; i++)
        {
            // Инициализация цветов в палетке

            var colorObject = Instantiate(colorPrefab, scrollViewContent);
            var script = colorObject.GetComponent<ColorElement>();

            script.MainMaterial = materials[i];
            script.DefaultParentTransform = scrollViewContent;

            // Делаем цвета интерактивными и добавляем на них триггер по нажатию 

            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerClick;
            entry.callback.AddListener((BaseEventData data) =>
            {
                OnItem(script);
            });
            EventTrigger trigger = script.GetComponent<EventTrigger>();
            trigger.triggers.Add(entry);
        }
    }

    public void OnItem(ColorElement item)
    {
        if(currentColor != null)
        {
            currentColor.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        currentColor = item;
        currentColor.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
    }
}
