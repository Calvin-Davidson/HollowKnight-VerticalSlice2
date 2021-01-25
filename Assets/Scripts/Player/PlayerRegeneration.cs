using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRegeneration : MonoBehaviour
{
    [SerializeField] private float regenerationTimeout = 1f;
    private float _regenTimeout = 0f;
    
    private PlayerData _playerData;
    private PlayerMovement _playerMovement;
    private PlayerInAir _playerInAir;
    private Animator _animator;
    private static readonly int Regenerating = Animator.StringToHash("regenerating");

    private bool _regenerated = false;

    private void Awake()
    {
        _playerData = GetComponent<PlayerData>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerInAir = GetComponent<PlayerInAir>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _regenTimeout += Time.deltaTime;
        if (_regenTimeout < regenerationTimeout) return;
        
        if (Input.GetKey(KeyCode.Z) && !_playerInAir.IsInAir() && _playerData.GetCurrentHealth() < _playerData.GetMaxPlayerHealth())
        {
            if (_regenerated == false)
            {
                _playerMovement.enabled = false;       
                _animator.SetBool(Regenerating, true);
            }
            else
            {
                _playerMovement.enabled = true;
                _regenerated = false;
                _playerData.ReceiveHealth();
                _animator.SetBool(Regenerating, false);
                _regenTimeout = 0f;
            }
        }
        else
        {
            _animator.SetBool(Regenerating, false);
            _playerMovement.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            _playerData.TakeDamage();
        }
    }

    public void DoneRegeneration()
    {
        _regenerated = true;
    }
}
