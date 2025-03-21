using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class ShieldController : MonoBehaviour
{
    [SerializeField] private Transform shield;

    private bool shieldActive = false;
    private float lastShieldActivationTime;
    private float shieldDuration;

    private void Update()
    {
        if (shieldActive)
        {
            if(Time.time - lastShieldActivationTime > shieldDuration)
            {
                StartCoroutine(ActivateShield());
            }
        }
    }

    private IEnumerator ActivateShield()
    {
        lastShieldActivationTime = Time.time;

        shield.gameObject.SetActive(true);
        gameObject.GetComponent<PlayerHealth>().isDamageable = false;

        yield return new WaitForSeconds(8f);
        DeactivateShield();
    }

    private void DeactivateShield()
    {
        shield.gameObject.SetActive(false);
        gameObject.GetComponent<PlayerHealth>().isDamageable = true;
    }

    public void SetShield(float duration)
    {
        shieldActive = true;
        shieldDuration = duration;
    }


}
