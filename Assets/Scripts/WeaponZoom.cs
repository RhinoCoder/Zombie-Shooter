using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float zoomedOutFov = 60f;
    [SerializeField] private float zoomedInFov = 30f;
    [SerializeField] private float zoomedInSensitivity = 2f;
    [SerializeField] private float zoomedOutSensitivity = 1f;
    [SerializeField] private RigidbodyFirstPersonController rigidbodyFirstPersonController;


    private bool zoomInToggle = false;


    private void OnDisable()
    {
        ZoomOut();
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            ZoomIn();
        }

        else
        {
            ZoomOut();
        }
    }

    private void ZoomIn()
    {
        mainCamera.fieldOfView = zoomedInFov;
        rigidbodyFirstPersonController.mouseLook.XSensitivity = zoomedInSensitivity;
        rigidbodyFirstPersonController.mouseLook.YSensitivity = zoomedInSensitivity;
    }

    private void ZoomOut()
    {
        mainCamera.fieldOfView = zoomedOutFov;
        rigidbodyFirstPersonController.mouseLook.XSensitivity = zoomedOutSensitivity;
        rigidbodyFirstPersonController.mouseLook.YSensitivity = zoomedOutSensitivity;
    }
}