using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{

     private float intensityVal = 5;
     private float angleAmount = 40;
     

     private void OnTriggerEnter(Collider other)
     {
          if (other.gameObject.CompareTag("Player"))
          {
               
               other.GetComponentInChildren<Flashlight>().RestoreLightAngle(angleAmount);
               other.GetComponentInChildren<Flashlight>().RestoreLightIntensity(intensityVal);
               Destroy(this.gameObject,0.1f);
          }
     }
}
