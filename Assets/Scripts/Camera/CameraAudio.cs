using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAudio : MonoBehaviour
{
    [SerializeField] private AudioSource attackAudio;
    [SerializeField] private AudioSource playerWalkAudio;
    
    public void PlayPlayerAttackAudio()
    {
        attackAudio.Play();
    }

    public void StopPlayerAttackAudio()
    {
        attackAudio.Stop();
    }
    public void PlayPlayerWalkAudio()
    {
        playerWalkAudio.Play();
    }

    public void StopPlayerWalkAudio()
    {
        playerWalkAudio.Stop();
    }
}
