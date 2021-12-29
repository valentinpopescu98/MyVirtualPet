using System.Collections.Generic;
using UnityEngine;

public class InventoryInteraction : MonoBehaviour
{
    public GameObject gameController;
    public List<Item> itemTypes = new List<Item>();

    ExperienceSystem xpSystemScript;

    void Start()
    {
        xpSystemScript = gameController.GetComponent<ExperienceSystem>();
    }

    // Add one item from all the possible types
    public void AddRandomItem()
    {
        Inventory.instance.AddItem(itemTypes[Random.Range(0, itemTypes.Count)]);
    }

    // Consume the current item
    public void UseItem(int index)
    {
        // Add xp
        xpSystemScript.crtXP += Inventory.instance.items[index].xp;

        // Remove item
        if (Inventory.instance.items[index] != null)
        {
            Inventory.instance.RemoveItem(Inventory.instance.items[index]);
        }
    }
}
