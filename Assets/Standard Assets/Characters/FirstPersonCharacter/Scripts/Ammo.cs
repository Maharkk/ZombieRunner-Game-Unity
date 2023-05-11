using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int AmmoClip = 30;

    public int AmmoAmmount()
    {
        return AmmoClip;
    }

    public void DecreaseAmmo()
    {
        AmmoClip--;
    }
}
