using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanelUI : MonoBehaviour
{
    [SerializeField] private GameObject upgradeCardPrefab;
    [SerializeField] private Transform upgradeCardParent;

    public void ShowCards(List<UpgradeType> upgrades, GameObject player, CarController car)
    {
        foreach (Transform child in upgradeCardParent)
        {
            Destroy(child.gameObject);
        }

        foreach (UpgradeType upgrade in upgrades)
        {
            GameObject card = Instantiate(upgradeCardPrefab, upgradeCardParent);
            card.GetComponent<UpgradeCardUI>().Setup(upgrade, player, car);
        }
    }

}
