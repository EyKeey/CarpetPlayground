using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeCardUI : MonoBehaviour
{
    private TextMeshProUGUI upgradeName;
    private TextMeshProUGUI description;
    private Image icon;
    private Button bttn;

    private UpgradeType upgrade;
    private GameObject player;
    private CarController car;

    private void Awake()
    {
        upgradeName = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        icon = transform.GetChild(1).GetComponent<Image>();
        description = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        bttn = GetComponent<Button>();
    }
    public void Setup(UpgradeType upgrade, GameObject player, CarController car)
    {
        this.upgrade = upgrade;
        this.player = player;
        this.car = car;

        upgradeName.text = upgrade.upgradeName;
        description.text = upgrade.description;
        icon.sprite = upgrade.icon;

        bttn.onClick.AddListener(() => SelectCard());
    }

    private void SelectCard()
    {
        UpgradeManager.instance.ApplyUpgrade(upgrade, player, car);
        //GameManager.instance.Continue();
        Time.timeScale = 1;
    }
}
