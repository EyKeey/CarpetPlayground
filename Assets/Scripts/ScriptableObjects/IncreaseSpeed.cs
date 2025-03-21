using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IncreaseSpeed", menuName = "SurvivalMod/Upgrades/IncreaseSpeed")]
public class IncreaseSpeed : UpgradeType
{
    public float speedIncrease = 0.3f;

    public override void ApplyUpgrade(GameObject player, CarController car)
    {
        car.carSpeed += car.carSpeed * speedIncrease;
    }
}
