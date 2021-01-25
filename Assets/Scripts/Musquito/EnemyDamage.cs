using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] PlayerData playerData;

    private void Awake()
    {
        playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerData>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            playerData.TakeDamage();
        }
    }
}
