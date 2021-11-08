using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject picture;

    [SerializeField] private Text levelComplete;

    private int maxCount;

    // Словарь, который хранит состояние объектов (1 - если верно, 0 - неверно)
    private Dictionary<string, int> partsState = new Dictionary<string, int>();
    void Start()
    {
        levelComplete.gameObject.SetActive(false);
        // Инициализируем, сколько объектов должно быть окрашено
        maxCount = picture.transform.childCount;
    }

    public void AddState(string name,int value)
    {
        if (partsState.ContainsKey(name))
            partsState[name] = value;
        else
            partsState.Add(name, value);

        IsComplete();
    }

    private void IsComplete()
    {
        int counter = 0;
        foreach (KeyValuePair<string, int> partState in partsState)
        {
            counter += partState.Value;
        }

        Debug.Log("New Check");
        foreach (KeyValuePair<string, int> partState in partsState)
        {   
            Debug.Log ("№ " + partState.Key + " - " + partState.Value);
        }

        if (counter == maxCount)
        {
            levelComplete.gameObject.SetActive(true);
        }
        else levelComplete.gameObject.SetActive(false);
    }
}
