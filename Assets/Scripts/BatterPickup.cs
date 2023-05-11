using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatterPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<FlashLight>().RestoreLight();
            Destroy(gameObject);
        }
    }
}
