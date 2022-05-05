using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private HealthSystem healthSystem;

    public GameObject healthBar;

    private RectTransform rt;

    private float healthSize = 355f;

    private float width;

    public void Setup(HealthSystem healthSystem)
    {
        this.healthSystem = healthSystem;
    }
    public void updateHealthBar(float percent)
    {
        rt = healthBar.GetComponent<RectTransform>();
        Debug.Log("health Size updated " + width);
        Debug.Log("Percent outside if" + percent);

        if (percent < 1 && percent >= 0)
        {
            width = healthSize - ((355f * (1- percent)));
            rt.sizeDelta = new Vector2((width), 46.5f);
            Debug.Log("Percent inside if" + (1- percent));
        }
    }
}
