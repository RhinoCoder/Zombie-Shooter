using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
     [SerializeField] private float hitPoints = 100f;


     private bool isDead = false;

     public bool IsDead()
     {
          return isDead;
     }

     public void TakeDamage(float damageAmount)
     {
          
          BroadcastMessage("OnDamageTaken");
          if (hitPoints > 0)
          {
               hitPoints -= damageAmount;
          }
          
          else
          {
               Die();
          }


     }


     private void Die()
     {
          if (isDead)
          {
               return;
          }
          isDead = true;
          GetComponent<Animator>().SetTrigger("die");
          
          
          
     }
     
     
     
     
}
