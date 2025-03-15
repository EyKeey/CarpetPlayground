using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;

    [SerializeField] private List<UpgradeType> allUpgrades;
    [SerializeField] private Transform upgradePanel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public List<UpgradeType> GetRandomUpgrade(int count)
    {
        List<UpgradeType> temp = new List<UpgradeType>(allUpgrades);
        List<UpgradeType> selected = new List<UpgradeType>();

        for (int i = 0; i < count && temp.Count > 0; i++)
        {
            int randomIndex = Random.Range(0, temp.Count);
            selected.Add(temp[randomIndex]);
            temp.RemoveAt(randomIndex);
        }

        return selected;
    }

    public void ApplyUpgrade(UpgradeType upgrade, GameObject player, CarController car)
    {
        upgrade.ApplyUpgrade(player, car);
        upgradePanel.gameObject.SetActive(false);
    }
}
