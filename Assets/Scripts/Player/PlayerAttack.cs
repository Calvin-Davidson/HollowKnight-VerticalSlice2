using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    
    private static readonly int Attacking = Animator.StringToHash("attacking");


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetBool(Attacking, true);
        }
        else
        {
            animator.SetBool(Attacking, false);
        }
    }
}
