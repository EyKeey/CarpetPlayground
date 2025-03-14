using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceManager : MonoBehaviour
{
    public static ExperienceManager instance;

    private float maxExperience = 100;
    [HideInInspector] public float currentExperience = 0;
    [HideInInspector] private float currentLevel = 1;


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
        }
        
        UIManager.instance.UpdateSlider(currentExperience, maxExperience);
    }   
}