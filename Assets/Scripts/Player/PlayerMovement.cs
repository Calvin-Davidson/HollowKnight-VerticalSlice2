using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    [SerializeField] private Animator animator;
    [SerializeField] private new Rigidbody2D rigidbody2D;
    private Transform _transform;
    
    
    // animator variables.
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Vertical = Animator.StringToHash("Vertical");

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    void Update()
    {
        int horizontalInput = (int) Input.GetAxisRaw("Horizontal");
        int verticalInput = (int) Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space)) verticalInput = 1;

        if (verticalInput == 0)
        {
            float currentY = rigidbody2D.velocity.y;
            rigidbody2D.velocity = new Vector2(movementSpeed * horizontalInput, currentY);
        }
        else
        {
            rigidbody2D.velocity = new Vector2(movementSpeed * horizontalInput,movementSpeed * verticalInput);
        }

        RotatePlayer(horizontalInput);
        UpdateAnimator(horizontalInput, verticalInput);
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


    private void UpdateAnimator(int horizontalInput,  int verticalInput)
    {
        animator.SetInteger(Horizontal, horizontalInput);
        animator.SetInteger(Vertical, verticalInput);
    }
}
