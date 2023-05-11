using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPcamera;
    [SerializeField] float range = 100f;
    [SerializeField] int damage = 25;
    [SerializeField] ParticleSystem muzzleflash;
    [SerializeField] GameObject HitVFX;
    [SerializeField] float TimeBetweenFire = 1f;
    [SerializeField] AmmoType ammoType;
    [SerializeField] Text AmmoText;
    Ammo Magazine;
    bool canshoot = true;

    private void Start()
    {
        Magazine = GetComponentInParent<Ammo>();
    }

    private void OnEnable()
    {
        canshoot = true;
    }

    void Update()
    { 
        if (Input.GetMouseButton(0) && canshoot == true)
        {
            StartCoroutine(Shoot());
        }
        AmmoText.text = Magazine.AmmoSize(ammoType).ToString();
    }
    IEnumerator Shoot()
    {
        canshoot = false;
        if (Magazine.AmmoSize(ammoType)> 0)
        {
            Magazine.DecreaseAmmo(ammoType);
            muzzleflash.Play();
            shoot();
        }
        else
        {
            Debug.Log("Out Of Ammo!");
        }
        yield return new WaitForSeconds(TimeBetweenFire);
        canshoot = true;
    }

    private void shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPcamera.transform.position, FPcamera.transform.forward, out hit, range))
        {
            EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();
            if (enemyHealth)
            {
                enemyHealth.GetComponent<EnemyAI>().isProvoked = true;
                enemyHealth.Decreasehealth(damage);
            }
            else
            {
                GameObject impact = Instantiate(HitVFX, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impact, 1);
            }
        }
        else
        {
            return;
        }
    }


}
