using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] private int ammoAmount = 5;
    [SerializeField] private AmmoType ammoType;
    
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            
            FindObjectOfType<Ammo>().IncreaseAmmo(ammoType,ammoAmount);
            Destroy(gameObject,0.2f);
            
        }
    }
}
