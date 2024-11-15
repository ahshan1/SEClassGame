using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Transform attackPoint; // just referecnes the attack point of the character - should be by the tip of weapon/fist maybe.
    public float attackRange = .5f;
    public int attackDamage = 20;


    public LayerMask enemyLayers;

    public Animator animator; // set inside the inspector.

   


    // Start is called before the first frame update






    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            Attack();
        }
        
        
    }


    void Attack ()
    {
        //play attack animation 

        animator.SetTrigger("Attack");


        //detect the enemies in range of attack 
        //creating an array that has all the enemies we hit.

        Collider2D [] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers); // creates a circle with a range we specify and collects all objects within range.


        // Damage them

            //loop through array from hitenemies and take away hp from each enemy. 

            // if null array just return
        if (hitEnemies == null)
        {
            return;
        }
        else
        {
            foreach (Collider2D enemy in hitEnemies)
            {

                Debug.Log("We hit" + enemy.name);

                // if null enemy go to the enxt
                if (enemy == null)
                {
                    continue;
                }
                

                    //get health.cs and use that to call the takedamage function.
                Health health = enemy.GetComponentInParent<Health>();


                if (health != null)
                {
                    health.TakeDamage(attackDamage);
                    Debug.Log("We hit" + enemy.name);
                }



                  
                   


                
            }

        }

    }


    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        else
        {
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }
}
