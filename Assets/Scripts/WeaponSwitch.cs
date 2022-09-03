using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{

      
     [SerializeField] private int currentWeapon = 0;
     [SerializeField] private Camera mainCamera;

     private void Start()
     {
          SetWeaponActive();
     }

     private void Update()
     {
          int prevWeapon = currentWeapon;

          ProcessKeyInput();
          ProcessScrollWheel();

          if (prevWeapon != currentWeapon)
          {
               SetWeaponActive();
          }
     }

     private void ProcessKeyInput()
     {
          if (Input.GetKeyDown(KeyCode.Alpha1))
          {
               currentWeapon = 0;
               
          }
          else if (Input.GetKeyDown(KeyCode.Alpha2))
          {
               currentWeapon = 1;
          }
          else if (Input.GetKeyDown(KeyCode.Alpha3))
          {
               currentWeapon = 2;
          }
          
     }

     private void ProcessScrollWheel()
     {
          if (Input.GetAxis("Mouse ScrollWheel") < 0)
          {

               if (currentWeapon >= transform.childCount - 1)
               {
                    currentWeapon = 0;
               }

               else
               {
                    currentWeapon++;
               }
               
               
          } 
          
          else if (Input.GetAxis("Mouse ScrollWheel") > 0)
          {

               if (currentWeapon <= 0)
               {
                    currentWeapon = transform.childCount-1;
               }

               else
               {
                    currentWeapon--;
               }
               
               
          }

           

     }

     void SetWeaponActive()
     {

          int weaponIndex = 0;
                   
          foreach (Transform weapon in transform)
          {
               if (weaponIndex == currentWeapon)
               {
                    weapon.gameObject.SetActive(true);
               }
               else
               {
                    weapon.gameObject.SetActive(false);
               }
               
               weaponIndex++;

          }

     }
}
