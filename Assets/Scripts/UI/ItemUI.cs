using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Image itemIcon;

    Item item;

    public void AddItemIcon(Item newItem)
    {
        item = newItem;

        itemIcon.sprite = item.icon;
        itemIcon.enabled = true;
    }

    public void RemoveItemIcon()
    {
        item = null;

        itemIcon.sprite = null;
        itemIcon.enabled = false;
    }
}
