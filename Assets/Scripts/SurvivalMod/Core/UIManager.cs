using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private GameObject xpSlider;
    [SerializeField] private GameObject healthBar;
    public Transform turboButton;

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

    public void UpdateXPSlider(float currentXP, float maxXP)
    {
        if(xpSlider != null)
        {
            xpSlider.GetComponent<Slider>().value = currentXP / maxXP;
        }
    }

    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {

        if (healthBar != null)
        {
            healthBar.GetComponent<Slider>().value = currentHealth / maxHealth;
        }
    }
}
