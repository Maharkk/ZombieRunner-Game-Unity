using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera viewcam;
    [SerializeField] float ZoomInSensitivity = 0.5f;
    [SerializeField] float ZoomOutSensitivity = 2f;

    private void OnEnable()
    {
        viewcam.fieldOfView = 60;
    }

    void Update()
    {
        
        if(Input.GetMouseButton(1))
        {
            viewcam.fieldOfView = 30;
            FindObjectOfType<RigidbodyFirstPersonController>().mouseLook.XSensitivity = ZoomInSensitivity;
            FindObjectOfType<RigidbodyFirstPersonController>().mouseLook.YSensitivity = ZoomInSensitivity;
        }
        else
        {
            viewcam.fieldOfView = 60;
            FindObjectOfType<RigidbodyFirstPersonController>().mouseLook.XSensitivity = ZoomOutSensitivity;
            FindObjectOfType<RigidbodyFirstPersonController>().mouseLook.YSensitivity = ZoomOutSensitivity;
        }
    }
}
