using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{


    public int maxHealth = 100;

    int currentHealth;

    public Animator animator;

    // Health Bar image
    public Image healthBar; // need to assign this using the image called green in Health UI in HUD

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        currentHealth = maxHealth;


        // health bar will reflect healt from beginnin.
        //updateHealthBar();

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        //currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);// this makes sure current health doesnt drop below 0.

        // update health bar 

        updateHealthBar();

        // play hurt animation

        if (currentHealth <= 0)
        {

            Die();
        }
    }


    void Die()
    {
        Debug.Log("Dead");

        // Die animation / hurt aniamtion and disable chracter.

        animator.SetTrigger("Dead");


    }


    void updateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth / 100f;
        }
        else
        {
            return;
        }
    }
}
