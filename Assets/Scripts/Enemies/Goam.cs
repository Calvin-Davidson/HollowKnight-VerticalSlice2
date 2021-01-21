using System.Collections;
using System.Collections.Generic;
//using UnityEngine.Animator;
using UnityEngine;

public class Goam : MonoBehaviour
{
    public Animator animator;


    void Start()
    {
        StartCoroutine("GoamActivity");
    }

    IEnumerator GoamActivity()
    {
        //Animation Active
        Debug.Log("On");
        animator.SetBool("isActive", true);
        yield return new WaitForSeconds(2f);
        //Animation Not Active
        Debug.Log("Off");
        animator.SetBool("isActive", false);
        yield return new WaitForSeconds(2f);
        StartCoroutine("GoamActivity");
    }

}
