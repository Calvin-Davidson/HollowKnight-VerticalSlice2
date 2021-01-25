using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAir : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private bool isInAir;
    private float _inAirFor;
    
    private static readonly int InAir = Animator.StringToHash("inAir");

    private void Update()
    {
        if (isInAir) _inAirFor += Time.deltaTime;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("FloorCollider"))
        {
            isInAir = false;
            animator.SetBool(InAir, false);
        }

        _inAirFor = 0f;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("FloorCollider"))
        {
            isInAir = true;
            animator.SetBool(InAir, true);
        }
    }


    public bool IsInAir()
    {
        return this.isInAir;
    }

    /**
     * returns how long the player was in air.
     */
    public float GetInAirFor()
    {
        return _inAirFor;
    }
}
