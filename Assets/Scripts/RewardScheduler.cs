using System.Collections;
using UnityEngine;

public class RewardScheduler : MonoBehaviour
{
    public GameObject inventory;
    public float timeForReward = 86400f;

    InventoryInteraction interaction;

    void Start()
    {
        interaction = inventory.GetComponent<InventoryInteraction>();

        StartCoroutine(GiveReward());
    }

    IEnumerator GiveReward()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeForReward);

            interaction.AddRandomItem();
        }
    }
}
