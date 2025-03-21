using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Regeneration", menuName = "SurvivalMod/Upgrades/Regeneration")]
public class Regeneration : UpgradeType
{
    public float regeneration = 0.03f;

    public override void ApplyUpgrade(GameObject player, CarController car)
    {
        player.GetComponent<PlayerHealth>().isRegenerationActive = true;
        player.GetComponent<PlayerHealth>().regenerationRate = regeneration;

    }
}
