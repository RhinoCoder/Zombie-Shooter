using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private PlayerHealth target;
    [SerializeField] private float damage = 30f;


    private void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }


    public void AttackHitEvent()
    {
        if (!target)
        {
            return;
        }

        target.GetComponent<PlayerHealth>().PlayerTakeDamage(damage);
        target.GetComponent<DisplayDamage>().ShowDamageImpact();
    }
}