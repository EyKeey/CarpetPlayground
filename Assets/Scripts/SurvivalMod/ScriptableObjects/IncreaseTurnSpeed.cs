using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IncreaseTurnSpeed", menuName = "SurvivalMod/Upgrades/IncreaseTurnSpeed")]
public class IncreaseTurnSpeed : UpgradeType
{
    public float turnSpeedIncrease = 0.3f;

    public override void ApplyUpgrade(GameObject player, CarController car)
    {
        car.turnSpeed += car.turnSpeed * turnSpeedIncrease;
    }
}
