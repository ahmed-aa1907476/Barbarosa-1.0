using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private HealthSystem healthSystem;


    public void Setup(HealthSystem healthSystem)
    {
        this.healthSystem = healthSystem;
    }

    private void Update()
    {
        Transform x = transform.Find("Bar");
        x.localScale =
            new Vector3(0.5f - ((1-healthSystem.getHealthPercent()) * 0.5f), 0.07f, 0.20f); 
        if (healthSystem.getHealthPercent() == 0)
            Destroy(gameObject.transform.parent.gameObject);
    }
}
