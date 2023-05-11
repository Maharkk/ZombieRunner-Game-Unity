using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int Health = 100;
    bool isDead = false;

    public void Decreasehealth(int damage)
    {
        Health -= damage;
        if(Health<=0)
        {
            GetComponent<Animator>().SetTrigger("Death");
            GetComponent<CapsuleCollider>().enabled = false;
            isDead = true;
        }
    }

    public bool IsDead()
    {
        return isDead;
    }
}
