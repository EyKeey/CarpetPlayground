using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private GameObject xpSlider;

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

    public void UpdateSlider(float currentXP, float maxXP)
    {
        if(xpSlider != null)
        {
            xpSlider.GetComponent<Slider>().value = currentXP / maxXP;
        }
    }

}
