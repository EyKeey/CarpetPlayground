using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootItem : MonoBehaviour, ICollectableItem
{
    public float xp;


    public void Collect()
    {
        Debug.Log("Loot collected");
        ExperienceManager.instance.IncreaseExperience(xp);
        Destroy(gameObject);
    }
}
