using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject[] attackParticleObjectLeft;
    [SerializeField] private GameObject[] attackParticleObjectRight;
    [SerializeField] private float attackDelay;
    private float _currentAttackDelay = 0f;

    private static readonly int Attacking = Animator.StringToHash("attacking");

    private CameraAudio _cameraAudio;

    private void Awake()
    {
        if (Camera.main != null)
        {
            _cameraAudio = Camera.main.GetComponent<CameraAudio>();
        }
        else
        {
            enabled = false;
            Debug.LogError("Main camera is niet gevonden");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentAttackDelay < attackDelay)
        {
            _currentAttackDelay += Time.deltaTime;
            animator.SetBool(Attacking, false);
            return;
        }


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _currentAttackDelay = 0;

            GameObject obj = Instantiate(attackParticleObjectRight[Random.Range(0, attackParticleObjectRight.Length)],
                transform.position,
                Quaternion.identity);

            animator.SetBool(Attacking, true);

            if (transform.localScale.x > 0)
            {
                Vector3 currentRotation = obj.transform.rotation.eulerAngles;
                currentRotation.y += 180;
                obj.transform.rotation = Quaternion.Euler(currentRotation);
            }

            _cameraAudio.PlayPlayerAttackAudio();
        }
        else
        {
            animator.SetBool(Attacking, false);
        }
    }
}