using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamangeTakeEffect : MonoBehaviour
{
    [SerializeField] private float timeSlowDownFor = 0.1f;
    [SerializeField] private PlayerData _playerData;

    private void Awake()
    {
        _playerData.onDamageTake.AddListener(OnDamageReceive);
    }

    void OnDamageReceive()
    {
        StartCoroutine(TimeSlowDown());
    }


    IEnumerator TimeSlowDown()
    {
        Time.timeScale = 0.1f;
        yield return new WaitForSeconds(timeSlowDownFor);
        Time.timeScale = 1f;
    }
}
