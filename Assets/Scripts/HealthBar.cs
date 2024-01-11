using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthbar;
    public float maxHealth  = 100;
    public float currentHealth;
    

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void UpdateHealthBar(int damage)
    {
        currentHealth-=damage;
        healthbar.fillAmount = currentHealth/maxHealth;
        
        /*if(currentHealth<=0)
        {
            Death();
        }
        */
    }

    

    public void Death()
    {
        Destroy(gameObject);
    }
    void Update()
    {
        
    }
}
