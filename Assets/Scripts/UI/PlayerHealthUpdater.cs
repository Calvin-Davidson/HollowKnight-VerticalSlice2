using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUpdater : MonoBehaviour
{
    [SerializeField] private Sprite active;
    [SerializeField] private Sprite inactive;
    [SerializeField] private PlayerData playerData;

    [SerializeField] private Image[] healthImages;

    private void Awake()
    {
        playerData.onDamageTake.AddListener(UpdateHealthUi);
        playerData.onHealthReceive.AddListener(UpdateHealthUi);
    }

    public void UpdateHealthUi()
    {
        for (int i = 0; i < healthImages.Length; i++)
        {
            if (playerData.GetCurrentHealth() > i)
            {
                healthImages[i].sprite = active;
            }
            else
            {
                healthImages[i].sprite = inactive;
            }
        }
    }
}