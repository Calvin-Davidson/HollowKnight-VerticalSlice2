using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField]EnemyAI enemyAI;
    [SerializeField]Animator animator;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            enemyAI.enabled = true;
            animator.SetBool("IsAttacking", true);
        }
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player"){
            enemyAI.enabled = false;
            animator.SetBool("IsAttacking", false);
        }
        
    }
}
