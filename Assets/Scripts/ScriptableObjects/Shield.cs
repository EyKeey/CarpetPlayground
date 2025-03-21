using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shield", menuName = "SurvivalMod/Upgrades/Shield")]
public class Shield : UpgradeType
{
    public float shieldDuration = 25;

    public override void ApplyUpgrade(GameObject player, CarController car)
    {
        player.GetComponent<ShieldController>().SetShield(shieldDuration);
    }
}
