using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    [SerializeField] AmmoType ammoType;
    [SerializeField] int increaseAmount=10;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PlayerHealth>())
        {
            FindObjectOfType<Ammo>().IncreaseAmmo(ammoType, increaseAmount);
            Destroy(gameObject);
        }
    }
}
