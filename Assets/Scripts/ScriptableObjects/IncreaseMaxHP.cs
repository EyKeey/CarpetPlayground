using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IncreaseMaxHP", menuName = "SurvivalMod/Upgrades/IncreaseMaxHP")]
public class IncreaseMaxHP : UpgradeType
{
    public float maxHPIncrease = 0.3f;

    public override void ApplyUpgrade(GameObject player, CarController car)
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

        playerHealth.maxHealth += playerHealth.maxHealth * maxHPIncrease;
    }
}
