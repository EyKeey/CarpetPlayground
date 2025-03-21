using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TurboBoost", menuName = "SurvivalMod/Upgrades/TurboBoost")]
public class TurboBoost : UpgradeType
{
    public float turboBoost = 2f;
    [SerializeField] Transform turboButtonUI;
 
    public override void ApplyUpgrade(GameObject player, CarController car)
    {
        turboButtonUI = UIManager.instance.turboButton;
        turboButtonUI.gameObject.SetActive(true);
        turboButtonUI.GetComponent<TurboButtonUI>().turboBoost = car.carSpeed * turboBoost;
    }
}
