using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageCollider : MonoBehaviour
{
    private PlayerData _playerData;

    private void Awake()
    {
        _playerData = GetComponent<PlayerData>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            _playerData.TakeDamage();
        }
    }
}
