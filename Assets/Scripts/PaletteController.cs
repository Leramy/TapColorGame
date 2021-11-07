using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PaletteController : MonoBehaviour
{
    [SerializeField] private GameObject colorPrefab;

    private ColorElement currentColor;

    public ColorElement CurrentColor
    {
        get { return currentColor; }
        set
        {
            if (value != null)
                currentColor = value;
        }
    }

    [SerializeField] private Transform scrollViewContent;

    [SerializeField] private List<Material> materials;


    void Start()
    {
        for (int i = 0; i < materials.Count; i++)
        {
            var colorObject = Instantiate(colorPrefab, scrollViewContent);
            var script = colorObject.GetComponent<ColorElement>();

            script.MainMaterial = materials[i];
            script.DefaultParentTransform = scrollViewContent;

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
