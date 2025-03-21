using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurboButtonUI : MonoBehaviour
{
    private GameObject player;
    private CarController car;
    private Button bttn;

    [HideInInspector] public float turboBoost;
    private float turboDuration = 5f;
    private float lastTurboTime;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        car = player.GetComponent<CarController>();
        bttn = GetComponent<Button>();
        bttn.onClick.AddListener(ActivateTurbo);

        lastTurboTime = 0;
        turboBoost = 0;
        
        gameObject.SetActive(false);
    }

    private void ActivateTurbo()
    {
        if(Time.time - lastTurboTime > turboDuration)
        {
            car.carSpeed += turboBoost;
            lastTurboTime = Time.time;
        }
    }
}
