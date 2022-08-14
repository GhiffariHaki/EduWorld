using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public PlayerData player;

    public HealthBar healthBar;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerData>();

        if(player.playerClass == 1)
        {
            maxHealth = 20;
        }
        else if (player.playerClass == 2)
        {
            maxHealth = 10;
        }
        else if (player.playerClass == 3)
        {
            maxHealth = 5;
        }

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Damage(1);
        }
    }

    public void Damage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

    }
    public void Heal(int heal)
    {
        currentHealth += heal;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);

    }
}
