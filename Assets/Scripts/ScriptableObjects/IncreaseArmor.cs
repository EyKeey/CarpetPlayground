using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IncreaseArmor", menuName = "SurvivalMod/Upgrades/IncreaseArmor")]
public class IncreaseArmor : UpgradeType
{
    public float armorIncrease = 0.05f;
    public override void ApplyUpgrade(GameObject player, CarController car)
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        playerHealth.armor += armorIncrease;
    }
}
