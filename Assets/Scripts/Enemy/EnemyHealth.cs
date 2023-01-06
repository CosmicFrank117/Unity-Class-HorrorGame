using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float enemyHP = 100f;

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        
        enemyHP -= damage;
        if (enemyHP <= 0)
        {
            GetComponent<Animator>().SetBool("Dead", true);
            GetComponent<EnemyAI>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
        }
    }
}
