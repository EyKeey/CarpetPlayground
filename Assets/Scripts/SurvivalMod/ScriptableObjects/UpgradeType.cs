using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeType", menuName = "SurvivalMod/UpgradeType")]
public class UpgradeType : ScriptableObject
{
    public string upgradeName;
    [TextArea] public string description;
    public Sprite icon;
    //public upgradeType type;


    public virtual void ApplyUpgrade(GameObject player, CarController car) { }

}
