using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;

    ItemUI[] itemsGFX;

    void Start()
    {
        Inventory.instance.onItemChangedCallback += UpdateUI;

        itemsGFX = itemsParent.GetComponentsInChildren<ItemUI>();
    }

    void UpdateUI()
    {
        for (int i = 0; i < itemsGFX.Length; i++)
        {
            if (i < Inventory.instance.items.Count)
            {
                itemsGFX[i].AddItemIcon(Inventory.instance.items[i]);
            }
            else
            {
                itemsGFX[i].RemoveItemIcon();
            }
        }
    }
}