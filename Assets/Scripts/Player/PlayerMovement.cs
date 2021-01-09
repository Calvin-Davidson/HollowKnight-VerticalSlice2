using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpHeight;

    [SerializeField] private Animator animator;
    [SerializeField] private new Rigidbody2D rigidbody2D;

    [SerializeField] private float inAirJumpTimer;
    [SerializeField] private AudioSource walkingAudio;
    
    private Transform _transform;
    private PlayerInAir _playerInAir;


    // animator variables.
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Vertical = Animator.StringToHash("Vertical");

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _playerInAir = GetComponent<PlayerInAir>();
        walkingAudio.loop = true;
    }

    void Update()
    {
        int horizontalInput = (int) Input.GetAxisRaw("Horizontal");
        int verticalInput = (int) Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space)) verticalInput = 1;

        if (verticalInput == 0 || (_playerInAir.IsInAir() && inAirJumpTimer <= _playerInAir.GetInAirFor())) 
        {
            float currentY = rigidbody2D.velocity.y;
            rigidbody2D.velocity = new Vector2(movementSpeed * horizontalInput, currentY);
        }
        else
        {
            rigidbody2D.velocity = new Vector2(movementSpeed * horizontalInput, jumpHeight * verticalInput);
        }

        RotatePlayer(horizontalInput);
        UpdateAnimator(horizontalInput, verticalInput);
        if (!_playerInAir.IsInAir() && horizontalInput != 0) 
        {
            PlayWalkingAudio();
        }
        else
        {
            StopWalkingSound();
        }
    }


    private void RotatePlayer(int horizontalInput)
    {
        Vector3 currentScale = _transform.localScale;
        if (horizontalInput == -1)
        {
            currentScale.x = -Math.Abs(transform.localScale.x);
            _transform.localScale = currentScale;
        }

        if (horizontalInput == 1)
        {
            currentScale.x = Math.Abs(transform.localScale.x);
            _transform.localScale = currentScale;
        }
    }


    private void UpdateAnimator(int horizontalInput, int verticalInput)
    {
        animator.SetInteger(Horizontal, horizontalInput);
        animator.SetInteger(Vertical, verticalInput);
    }

    private void PlayWalkingAudio()
    {
        if (walkingAudio.isPlaying) return;
        walkingAudio.Play();
    }

    private void StopWalkingSound()
    {
        walkingAudio.Stop();
    }
}