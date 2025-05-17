using UnityEngine;
using UnityEngine.UI;

public class HealthManager : Stats
{
    public Image healthBar;
    public float healthAmount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthAmount = hp; // Initialize health amount to max health
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage; //Decreases the health amount by damage taken
        healthBar.fillAmount = healthAmount / hp; //Updates the health bar fill amount
    }

    public void getHealed(float healing)
    {
        healthAmount += healing;
        healthAmount = Mathf.Clamp(healthAmount, 0, hp); //Ensures that health amount does not exceed max health

        healthBar.fillAmount = healthAmount / hp; //Updates the health bar fill amount
    }
}
