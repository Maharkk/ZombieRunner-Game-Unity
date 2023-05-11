using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }
    
    public int AmmoSize(AmmoType ammoType)
    {
        var slot = GetSlot(ammoType);
        return slot.ammoAmount;
    }

    public void DecreaseAmmo(AmmoType ammoType)
    {
        var slot = GetSlot(ammoType);
        slot.ammoAmount--;
    }

    public void IncreaseAmmo(AmmoType ammoType,int increaseAmount)
    {
        var slot = GetSlot(ammoType);
        slot.ammoAmount += increaseAmount;
    }

    private AmmoSlot GetSlot(AmmoType ammoType)
    {
        foreach(AmmoSlot slot in ammoSlots )
        { 
            if (slot.ammoType==ammoType)
            {
                return slot;
            }
        }
        return null;
    }
}
