using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int Health = 100;
    [SerializeField] Canvas GameOverCanvas;
    [SerializeField] Canvas DamageCanvas;
    void Start()
    {
        Time.timeScale = 1;
        GameOverCanvas.enabled = false;
        DamageCanvas.enabled = false;
    }

    public void decrease(int damage)
    {
        Health -= damage;
        if(Health<=0)
        {
            GameOverCanvas.enabled = true;
            Time.timeScale = 0;
            FindObjectOfType<SwitchWeapon>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    IEnumerator DisplayDamage()
    {
        DamageCanvas.enabled = true;
        yield return new WaitForSeconds(.5f);
        DamageCanvas.enabled = false;
    }
   
}
