using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAir : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private bool isInAir;
    
    
    private static readonly int InAir = Animator.StringToHash("inAir");

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("FloorCollider"))
        {
            isInAir = false;
            animator.SetBool(InAir, false);
        }
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
}
