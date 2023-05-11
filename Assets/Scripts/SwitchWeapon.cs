using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchWeapon : MonoBehaviour
{
    [SerializeField] int CurrentWeapon = 0;
    [SerializeField] Text GunName;
    void Start()
    {
        SetActiveWeapons();
    }

    void Update()
    {
        int previousweapon = CurrentWeapon;
        
        ProcessKeyboardInput();
        ProcessScrollInput();
        if (previousweapon!=CurrentWeapon)
        {
            SetActiveWeapons();
        }
    }

    private void ProcessScrollInput()
    {
        if(Input.GetAxis("Mouse ScrollWheel")<0)
        {
            if(CurrentWeapon>=transform.childCount-1)
            {
                CurrentWeapon = 0;
            }
            else
            {
                CurrentWeapon++;
            }
        }
        else if(Input.GetAxis("Mouse ScrollWheel")>0)
        {
            if(CurrentWeapon<=0)
            {
                CurrentWeapon = transform.childCount - 1;
            }
            else
            {
                CurrentWeapon--;
            }
        }
    }

    private void ProcessKeyboardInput()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            CurrentWeapon = 0;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            CurrentWeapon = 1;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            CurrentWeapon = 2;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            CurrentWeapon = 3;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            CurrentWeapon = 4;
        }
    }

    private void SetActiveWeapons()
    {
        int currentIndex = 0;
        foreach(Transform weapon in transform)
        {
            if (currentIndex==CurrentWeapon)
            {
                weapon.gameObject.SetActive(true);
                GunName.text = weapon.gameObject.name;
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            currentIndex++;
            
        }
    }

}
