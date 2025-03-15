using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceManager : MonoBehaviour
{
    public static ExperienceManager instance;

    private float maxExperience = 100;
    [HideInInspector] public float currentExperience = 0;
    [HideInInspector] private float currentLevel = 1;

    [SerializeField] private Transform upgradePanelUI;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UIManager.instance.UpdateXPSlider(currentExperience, maxExperience);
    }

    public void IncreaseExperience(float amount)
    {
        currentExperience += amount;
        UpdateLevel();
     }

    public void UpdateLevel()
    {
        if (currentExperience >= maxExperience)
        {
            currentExperience = 0;
            maxExperience *= 1.3f;
            currentLevel++;

            //GameManager.instance.Pause();
            Time.timeScale = 0;

            var upgrades = UpgradeManager.instance.GetRandomUpgrade(3);

            upgradePanelUI.gameObject.SetActive(true);
            upgradePanelUI.GetComponent<UpgradePanelUI>().ShowCards(upgrades, GameObject.FindGameObjectWithTag("Player"), FindObjectOfType<CarController>());

        }

        UIManager.instance.UpdateXPSlider(currentExperience, maxExperience);
    }   
}