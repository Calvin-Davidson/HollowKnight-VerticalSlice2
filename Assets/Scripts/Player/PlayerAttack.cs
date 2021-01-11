using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject[] attackParticleObjectLeft;
    [SerializeField] private GameObject[] attackParticleObjectRight;
    private static readonly int Attacking = Animator.StringToHash("attacking");


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (transform.localScale.x < 0)
            {
                animator.SetBool(Attacking, true);
                Instantiate(attackParticleObjectLeft[Random.Range(0, attackParticleObjectLeft.Length)], transform.position,
                    Quaternion.identity);   
            }
            else
            {
                animator.SetBool(Attacking, true);
                GameObject obj = Instantiate(attackParticleObjectRight[Random.Range(0, attackParticleObjectRight.Length)], transform.position,
                    Quaternion.identity);

                Vector3 currentRotation = obj.transform.rotation.eulerAngles;
                currentRotation.y += 180;
                obj.transform.rotation = Quaternion.Euler(currentRotation);
            }
        }
        else
        {
            animator.SetBool(Attacking, false);
        }
    }
}
