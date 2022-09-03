using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private float maxHealth = 100f;

    
 
    public void PlayerTakeDamage(float damage)
    {


        maxHealth -= damage;

        if (maxHealth <= 0)
        {

            //Destroy(gameObject, 0.1f);
            GetComponent<DeathHandler>().HandleDeath();
            Debug.Log("I am dead");
            
        }





    }
    
    
}
