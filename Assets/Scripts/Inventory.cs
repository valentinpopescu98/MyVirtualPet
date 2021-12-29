using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int space;
    public List<Item> items = new List<Item>();

    [HideInInspector] public delegate void OnItemChanged();
    [HideInInspector] public OnItemChanged onItemChangedCallback;
    [HideInInspector] public static Inventory instance;

    ItemUI itemUI;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one inventory instances!");
            return;
        }

        instance = this;
    }

    public void AddItem(Item item)
    {
        if (items.Count >= space)
        {
            return;
        }

        items.Add(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
