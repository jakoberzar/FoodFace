using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider slider;
    float health = 100;
    float maxHealth = 100;
    // Start is called before the first frame update

    public void SetHealth(float health)
    {
        this.health = health;
        slider.value = Mathf.Min(health, maxHealth) / maxHealth;
    }
}
