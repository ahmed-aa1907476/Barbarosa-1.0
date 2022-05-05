using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem 
{
    private int health;
    private int maxHealth;
    public HealthSystem(int maxHealth) {
        this.maxHealth = maxHealth;
        health = maxHealth;
    }

    public int getHealth() {
        return health;
    }

    public float getHealthPercent() {
        float percentage = (float) health/maxHealth;
        return percentage;
    }

    public float Damage(int damageAmount)
    {
        Debug.Log("HeaLTH Level : " + health);
        if (health > 0) {
            health -= damageAmount;
        }
        return health;
    }
    public void Heal(int healAmount)
    {
        health += healAmount;
        if (health > maxHealth) {
            health = maxHealth;
        }
    }
}
