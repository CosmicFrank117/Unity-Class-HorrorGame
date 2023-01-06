using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHP = 100f;

    public void damagePlayer(float damage)
    {
        playerHP -= damage;

        if (playerHP <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
