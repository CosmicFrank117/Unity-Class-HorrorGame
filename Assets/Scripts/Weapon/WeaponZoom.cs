using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] RigidbodyFirstPersonController fpsController;

    [SerializeField] float unzoomedFOV = 60f;
    [SerializeField] float zoomedFOV = 30f;
    [SerializeField] float unzoomedSensitivity = 2f;
    [SerializeField] float zoomedSensitivity = 1f;

    bool zoomedInToggle = false;

    private void OnDisable() 
    {
        ZoomOut();
    }

    private void Update()
    {
       if (Input.GetMouseButtonDown(1))
       {
           ToggleZoom();
       }
    }

    void ToggleZoom()
    {
        if (zoomedInToggle == false)
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
        zoomedInToggle = true;
        mainCamera.fieldOfView = zoomedFOV;

        fpsController.mouseLook.XSensitivity = zoomedSensitivity;
        fpsController.mouseLook.YSensitivity = zoomedSensitivity;
    }

    private void ZoomOut()
    {
        zoomedInToggle = false;
        mainCamera.fieldOfView = unzoomedFOV;

        fpsController.mouseLook.XSensitivity = unzoomedSensitivity;
        fpsController.mouseLook.YSensitivity = unzoomedSensitivity;
    }
}
