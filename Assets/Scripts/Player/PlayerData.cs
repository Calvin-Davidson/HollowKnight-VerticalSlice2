using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private int maxPlayerHealth = 5;
    private int _currentPlayerHealth;
    
    [SerializeField] public UnityEvent onDamageTake = new UnityEvent();
    [SerializeField] public UnityEvent onHealthReceive = new UnityEvent();
    [SerializeField] public UnityEvent onPlayerDieEvent = new UnityEvent();


    private void Awake()
    {
        _currentPlayerHealth = maxPlayerHealth;
    }
    
    public void TakeDamage()
    {
        _currentPlayerHealth -= 1;
        onDamageTake.Invoke();

        if (_currentPlayerHealth.Equals(0))
        {
            onPlayerDieEvent.Invoke();

            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }

    public void ReceiveHealth()
    {
        if (_currentPlayerHealth == maxPlayerHealth) return;
        _currentPlayerHealth += 1;
       onHealthReceive.Invoke();
    }


    public int GetCurrentHealth()
    {
        return this._currentPlayerHealth;
    }

    public int GetMaxPlayerHealth()
    {
        return this.maxPlayerHealth;
    }
}
